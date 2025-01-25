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

        [HttpGet]
        public JsonResult GetDetails(int id)
        {
            var result = _context.HotelBookings.Find(id);
            if (result == null)
             return new JsonResult(NotFound()); 
            return new JsonResult(Ok(result));
        }

        [HttpGet("/GetAll")]
        public IActionResult GetAllDetails()
        {
            var result = _context.HotelBookings.All(c => c.Id >= 0) ? _context.HotelBookings.ToList(): null;

           // .All(c => c.Id >= 0);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.HotelBookings.Find(id);
            if (result == null)
                return NotFound();
            _context.HotelBookings.Remove(result);
            _context.SaveChanges();
            return Ok("Deleted");
        }

    }
}
