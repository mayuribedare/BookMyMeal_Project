using DL_BMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BMM.Interface
{
    public interface IBookingDAL
    {
        public List<Booking> GetBookingDetails(int Eid);
        Task CreateBooking(Booking booking);
       public void CancelBooking(int Booking_id);
    }
}
