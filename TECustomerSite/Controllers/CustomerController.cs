using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TECustomerSite.Models;

namespace TECustomerSite.Controllers
{
    /// <summary>
    /// Customer controller for methods of the Customer Edit Page and Customer Profile Page 
    /// Author: Brianna Gibson 
    /// Date: August 2022
    /// </summary>
    public class CustomerController : Controller
    {
        // GET: CustomerController using session of user logged in
        [Authorize]
        public ActionResult Index(int id)
        {
            if (HttpContext.Session.GetInt32("CurrentCustomer") > 0)
            {
                id = HttpContext.Session.GetInt32("CurrentCustomer") ?? 0;
            }
            Customer customer = CustomerManager.FindCustomer(id);
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            // finds the customer based on the user logged in 
            if (HttpContext.Session.GetInt32("CurrentCustomer") > 0)
            {
                id = HttpContext.Session.GetInt32("CurrentCustomer") ?? 0;
            }
            Customer customer = CustomerManager.FindCustomer(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer newData)
        {
            if (HttpContext.Session.GetInt32("CurrentCustomer") > 0)
            {
                id = HttpContext.Session.GetInt32("CurrentCustomer") ?? 0;
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
