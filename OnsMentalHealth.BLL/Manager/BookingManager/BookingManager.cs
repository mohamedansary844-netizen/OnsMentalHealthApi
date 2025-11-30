using OnsMentalHealth.BLL.DTOs;
using OnsMentalHealth.DAl.Reposatory;
using OnsMentalHealthSolution.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepo _bookingRepo;

        public BookingManager(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<BookingReadDTO?> AddBookingAsync(BookingAddDTO bookingAddDTO)
        {
            var existingBookings = await _bookingRepo.GetBookingAsync();

            bool conflict = existingBookings.Any(b =>
                b.TherapistId == bookingAddDTO.TherapistId &&
                b.BookingDate == bookingAddDTO.BookingDate &&
                b.BookingTime == bookingAddDTO.BookingTime
            );

            if (conflict) return null;

            var booking = new Booking
            {
                TherapistId = bookingAddDTO.TherapistId,
                UserId = bookingAddDTO.UserId,
                UserName = bookingAddDTO.UserName,
                UserEmail = bookingAddDTO.UserEmail,
                UserPhoneNumber = bookingAddDTO.UserPhoneNumber,
                BookingDate = bookingAddDTO.BookingDate,
                BookingTime = bookingAddDTO.BookingTime,
                BookingType = bookingAddDTO.BookingType,
                Status = "Pending",
                ImageUrl = bookingAddDTO.ImageUrl
            };

            await _bookingRepo.AddBookingAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            return new BookingReadDTO
            {
                BookingId = booking.BookingId,
                BookingType = booking.BookingType,
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                Status = booking.Status,
                TherapistId = booking.TherapistId,
                UserId = booking.UserId,
                UserName = booking.UserName,
                ImageUrl = booking.ImageUrl,
                UserEmail = booking.UserEmail,
                UserPhoneNumber = booking.UserPhoneNumber
            };
        }

        public async Task<IEnumerable<BookingReadDTO>> GetBookingAsync()
        {
            var bookings = await _bookingRepo.GetBookingAsync();
            return bookings.Select(b => new BookingReadDTO
            {
                BookingId = b.BookingId,
                BookingType = b.BookingType,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                Status = b.Status,
                TherapistId = b.TherapistId,
                UserId = b.UserId,
                UserName = b.UserName,
                ImageUrl = b.ImageUrl,
                UserEmail = b.UserEmail,
                UserPhoneNumber = b.UserPhoneNumber
            }).ToList();
        }

        public async Task<BookingReadDTO?> GetBookingByIdAsync(int id)
        {
            var b = await _bookingRepo.GetBookingByIdAsync(id);
            if (b == null) return null;

            return new BookingReadDTO
            {
                BookingId = b.BookingId,
                BookingType = b.BookingType,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                Status = b.Status,
                TherapistId = b.TherapistId,
                UserId = b.UserId,
                UserName = b.UserName,
                ImageUrl = b.ImageUrl,
                UserEmail = b.UserEmail,
                UserPhoneNumber = b.UserPhoneNumber
            };
        }

        public async Task<IEnumerable<BookingReadDTO>> GetBookingsByUserAsync(string userId)
        {
            var bookings = await _bookingRepo.GetBookingAsync();
            return bookings.Where(b => b.UserId == userId)
                .Select(b => new BookingReadDTO
                {
                    BookingId = b.BookingId,
                    BookingType = b.BookingType,
                    BookingDate = b.BookingDate,
                    BookingTime = b.BookingTime,
                    Status = b.Status,
                    TherapistId = b.TherapistId,
                    UserId = b.UserId,
                    UserName = b.UserName,
                    ImageUrl = b.ImageUrl,
                    UserEmail = b.UserEmail,
                    UserPhoneNumber = b.UserPhoneNumber
                }).ToList();
        }

        public async Task<BookingReadDTO?> UpdateBookingAsync(int id, BookingUpdateDTO dto)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(id);
            if (booking == null) return null;

            booking.BookingType = dto.BookingType;
            booking.BookingDate = dto.BookingDate;
            booking.BookingTime = dto.BookingTime;
            booking.UserName = dto.UserName;
            booking.UserPhoneNumber = dto.UserPhoneNumber;
            booking.UserEmail = dto.UserEmail;

            await _bookingRepo.SaveChangesAsync();

            return new BookingReadDTO
            {
                BookingId = booking.BookingId,
                BookingType = booking.BookingType,
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                Status = booking.Status,
                TherapistId = booking.TherapistId,
                UserId = booking.UserId,
                UserName = booking.UserName,
                ImageUrl = booking.ImageUrl,
                UserEmail = booking.UserEmail,
                UserPhoneNumber = booking.UserPhoneNumber
            };
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(id);
            if (booking != null)
            {
                await _bookingRepo.DeleteBookingAsync(booking);
                await _bookingRepo.SaveChangesAsync();
            }
        }
    }
}
