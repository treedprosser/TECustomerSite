using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TECustomerSite.Models;

namespace TECustomerSite.Controllers
{
    public class AccountController : Controller
    {
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
