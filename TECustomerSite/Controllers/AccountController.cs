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
			{
				TempData["LoginFailed"] = "Incorrect username or password";
				return View();
			}

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
    }
}
