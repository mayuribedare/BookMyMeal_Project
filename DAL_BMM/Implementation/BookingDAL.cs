using DAL_BMM.Interface;
using DL_BMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BMM.Implementation
{
    public class BookingDAL : IBookingDAL
    {
        private readonly BookMyMealContext _db;

        public BookingDAL(BookMyMealContext db)
        {
            _db = db;
        }

        public async Task CreateBooking(Booking booking)
        {
            _db.Bookings.AddAsync(booking);
            await _db.SaveChangesAsync();
        }

        public void CancelBooking(int Booking_id)
        {

            var booking = _db.Bookings.FirstOrDefault(b => b.BookingId == Booking_id);
           
            if(booking != null)
            {
               _db.Bookings.Remove(booking);
               _db.SaveChanges();
            }
            
        }

        public List<Booking> GetBookingDetails(int Eid)
        {
            List<Booking> booking = new List<Booking>();
            booking =_db.Bookings.Where(e => e.Eid == Eid).ToList();
            return booking;
        }
    }
}
