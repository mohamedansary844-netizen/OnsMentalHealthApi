using OnsMentalHealth.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager
{
    public interface IBookingManager
    {
        Task<BookingReadDTO?> AddBookingAsync(BookingAddDTO bookingAddDTO);
        Task<IEnumerable<BookingReadDTO>> GetBookingAsync();
        Task<BookingReadDTO?> GetBookingByIdAsync(int id);

        Task<IEnumerable<BookingReadDTO>> GetBookingsByUserAsync(string userId);
        Task<BookingReadDTO?> UpdateBookingAsync(int id, BookingUpdateDTO dto);
        Task DeleteBookingAsync(int id);
    }
}
