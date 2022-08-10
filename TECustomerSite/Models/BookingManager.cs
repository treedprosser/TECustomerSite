using Microsoft.EntityFrameworkCore;

namespace TECustomerSite.Models
{
    public class BookingManager
    {
      // get bookings
        public static List<Booking> GetAll()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            List<Booking> bookings = db.Bookings.Include(r => r.Customer).Include(r => r.BookingDetails).ToList();
            return bookings;
        }
        public static List<Booking> GetBooking()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            List<Booking> bookings = db.Bookings.ToList();
            return bookings;

        }
    }
}
