using HotelBookingAPI.Data;
using HotelBookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateEdit(HotelBooking hotel)
        {
            if (hotel.Id == 0)
            {
                // Create new hotel booking
                _context.HotelBookings.Add(hotel);
            } 
            else
            {
                // Update existing hotel booking
                var existingHotel = _context.HotelBookings.Find(hotel.Id);
                if (existingHotel == null)
                {
                    return NotFound();
                }
                existingHotel = hotel;
            }
            _context.SaveChanges();
            return Ok(hotel);
        }
    }
}
