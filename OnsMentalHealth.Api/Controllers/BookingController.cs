using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnsMentalHealth.BLL.DTOs;
using OnsMentalHealth.BLL.Manager;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnsMentalHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookings = await _bookingManager.GetBookingsByUserAsync(userId);
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingManager.GetBookingByIdAsync(id);
            if (booking == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            if (booking.UserId != userId) return Forbid();
            return Ok(booking);
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBooking([FromBody] BookingAddDTO bookingAddDTO)
        {
            if (bookingAddDTO == null) return BadRequest("Invalid payload");

            bookingAddDTO.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bookingAddDTO.UserEmail = User.FindFirstValue(ClaimTypes.Email);

            var created = await _bookingManager.AddBookingAsync(bookingAddDTO);

            if (created == null)
                return Conflict(new { message = "Sorry, this time or date is already booked for this therapist." });

            return CreatedAtAction(nameof(GetBookingById), new { id = created.BookingId }, created);
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDTO dto)
        {
            var booking = await _bookingManager.GetBookingByIdAsync(id);
            if (booking == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (booking.UserId != userId)
                return Forbid();

            var updated = await _bookingManager.UpdateBookingAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _bookingManager.GetBookingByIdAsync(id);
            if (booking == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            if (booking.UserId != userId) return Forbid();

            await _bookingManager.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
