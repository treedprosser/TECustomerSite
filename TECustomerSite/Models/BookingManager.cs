using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TECustomerSite.Models
{
    public class BookingManager
    {
        public static List<BookingDetail> GetBookingDetails(int custID)
        {
            List<Booking> custBookings = null;
            List<BookingDetail> custDetails = null;
            TravelExpertsContext db = new TravelExpertsContext();

            custBookings = db.Bookings.Where(b => b.CustomerId == custID).ToList();

            foreach (Booking booking in custBookings)
            {
                custDetails = db.BookingDetails.Where(b => b.BookingId == booking.BookingId).ToList();
            }

            return custDetails;
        }
    }
}
