using DL_BMM.Models;
using DL_BMM.request;
using DL_BMM.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_BMM.Interface
{
    public interface IBookingBAL
    {
        public List<Booking> GetBookingDetails(int Eid);
        Task<Booking>CreateBooking(int Eid,DateTime date);

        public void CancelBooking(int Booking_id);
    }
}
