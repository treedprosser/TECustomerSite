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
            List<BookingDetail> bookings = null;
            int? customerID = HttpContext.Session.GetInt32("CurrentCustomer");
            // Could create a BookingsManager class and add a method to it that will grab all the bookings for a given customer ID
            // Then call the method on the list created above, something like what's written below
            // bookings = BookingsManager.GetBookingsByCustomer((int)customerID);
            return View(bookings);
        }
    }
}
