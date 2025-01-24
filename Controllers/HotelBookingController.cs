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
            }
            else
            {
                // Update existing hotel booking
            }
            return Ok(hotel);
        }
    }
}
