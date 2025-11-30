using OnsMentalHealthSolution.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Reposatory
{
    public interface IBookingRepo
    {
        Task<Booking> AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetBookingAsync();
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<Booking?> UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(Booking booking);
        Task SaveChangesAsync();
    }
}
