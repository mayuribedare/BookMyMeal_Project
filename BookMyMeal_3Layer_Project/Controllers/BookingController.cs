using BAL_BMM.Interface;
using DL_BMM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using DAL_BMM.Interface;
using Azure.Core;
using DL_BMM.Response;
using DL_BMM.request;
using Microsoft.AspNetCore.Authorization;

namespace BookMyMeal_3Layer_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingBAL _bookingbal;
        public BookingController(IBookingBAL bookingbal)
        {
            _bookingbal = bookingbal;
        }

   
        [Route("BookingDetails")]
        [HttpGet]
        public IActionResult GetBooking(int Eid)
        {

            var booking = _bookingbal.GetBookingDetails(Eid);
            if (booking == null)
            {
                return NotFound();
            }
            
            return Ok(booking);
        }


        [Route("createBooking")]
        [HttpPost]
        public async Task<ActionResult<BookingResponse>>CreateBooking(BookingRequest request)
        {

            var result = await _bookingbal.CreateBooking(request.Eid,Convert.ToDateTime(request.Date));
            return Ok(new {Message = "Booking Successful",result.BookingId});
        }


        [Route("cancelBooking")]
        [HttpPost]
        public IActionResult CancelBooking(int Booking_id)
        {
            try
            {
                _bookingbal.CancelBooking(Booking_id);
                return Ok(new { Message = "Booking Canceled successful", Booking_id });

            }
            catch(Exception ex)
            {
                return StatusCode(500, "error occurred while canceling the booking");
            }
        }
       
    }
}
