using Microsoft.AspNetCore.Mvc;

namespace TECustomerSite.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
         
            return View();
        }
    }
}
