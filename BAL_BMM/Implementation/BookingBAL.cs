using BAL_BMM.Interface;
using DAL_BMM.Implementation;
using DL_BMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BMM.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DL_BMM.Response;
using DL_BMM.request;
using System.Web.Http.Results;

namespace BAL_BMM.Implementation
{
    public class BookingBAL : IBookingBAL
    {
        private readonly IBookingDAL _bookingDAL;

        public BookingBAL(IBookingDAL bookingDAL)
        {
            _bookingDAL = bookingDAL;
        }

        public List<Booking> GetBookingDetails(int Eid)
        {
           List<Booking> result = new List<Booking>();
            result = _bookingDAL.GetBookingDetails(Eid);
           return result;
        }

        public async Task<Booking> CreateBooking(int Eid, DateTime date)
        {
            var Books = new Booking
            {
                Eid = Eid,
                Date = date
            };

            await _bookingDAL.CreateBooking(Books);
            return Books;


        }


        public void CancelBooking(int Booking_id)
        {
            _bookingDAL.CancelBooking (Booking_id);
            //var books = _bookingDAL.GetBookingDetails(Booking_id);

            //if (books == null)
            //{
            //   return "Booking not found.";
            //}
            //else
            //{
            //    _bookingDAL.CancelBooking(Booking_id);
            //   return "Booking deleted successfully.";
            //}
        }

    }
}
