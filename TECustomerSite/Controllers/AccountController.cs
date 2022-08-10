using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TECustomerSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TECustomerSite.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login( string? returnUrl = null)
		{
			if (returnUrl != null)
				TempData["returnUrl"] = returnUrl;
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> LoginAsync( Customer customer )
		{
			TravelExpertsContext db = new TravelExpertsContext();
			var usr = db.Customers
				.Where( c => c.Username == customer.Username && c.Password == customer.Password )
				.FirstOrDefault();

			if (usr == null)
				return View();

            HttpContext.Session.SetInt32("CurrentCustomer", (int)usr.CustomerId);


			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, usr.Username),
				new Claim("FirstName", usr.CustFirstName)
			};

			var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

			await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

			if (TempData["ReturnUrl"] == null)
				return RedirectToAction("Index", "Home"); //change this depending on the final version of the project
			else
				return Redirect(TempData["ReturnUrl"].ToString());
		}

		public async Task<IActionResult> LogoutAsync()
		{
            //int? custID = HttpContext.Session.GetInt32("CurrentCustomer");
            //if (custID != null)
            //    HttpContext.Session.Remove("CurrentCustomer");
			await HttpContext.SignOutAsync("Cookies");
			return RedirectToAction("Index", "Home");
		}

        public IActionResult Register()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer customer)
        {
            try
            {
                CustomerManager.Register(customer);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                TempData["IsError"] = true;
                TempData["Message"] = "Error registering, please try again later";
                return View();
            }
        }

        [Authorize]
		public IActionResult Edit(int id)
        {
            Customer customer = CustomerManager.FindCustomer(id);
            return View(customer);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
		public IActionResult Edit(int id, Customer newData)
        {
            if (HttpContext.Session.GetInt32("CurrentCustomer") > 0)
            {
                id = HttpContext.Session.GetInt32("CurrentCustomer")??0;
            }
            try
            {
                CustomerManager.UpdateCustomer(id, newData);
                TempData["Message"] = $"Successfully updated {newData.CustFirstName}'s information";
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
				TempData["IsError"] = true;
				TempData["Message"] = "Error when attempting to edit Customer";
				return View();
            }
        }
    }
}
