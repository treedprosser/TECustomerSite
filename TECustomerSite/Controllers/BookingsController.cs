using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TECustomerSite.Models;

namespace TECustomerSite.Controllers
{
    public class BookingsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            List<BookingDetail> bookings;
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            bookings = BookingManager.GetBookingDetails((int)customerID);
            return View(bookings);
        }
    }
}
