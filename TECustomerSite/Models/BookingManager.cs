using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TECustomerSite.Models
{
    public class BookingManager
    {
        public static List<BookingDetail> GetBookingDetails(int custID)
        {
			
			//List<Booking> custBookings = null;
			//List<BookingDetail> custDetails = null;
			TravelExpertsContext db = new TravelExpertsContext();
			List<int> bookingIDS;
			List<BookingDetail> bookingDetails;

			bookingIDS = db.Bookings.Where(b => b.CustomerId == custID).Select(b => b.BookingId).ToList();
            
			bookingDetails = db.BookingDetails.Where(b => b.BookingId != null && bookingIDS.Contains((int)b.BookingId)).ToList();

            return bookingDetails;
        }
    }
}
