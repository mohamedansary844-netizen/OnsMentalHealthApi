using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Reposatory
{
    public class BookingRepo : IBookingRepo
    {
        private readonly OnsDbContext _onsDbContext;

        public BookingRepo(OnsDbContext onsDbContext)
        {
            _onsDbContext = onsDbContext;
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            await _onsDbContext.Bookings.AddAsync(booking);
            return booking;
        }

        public async Task<IEnumerable<Booking>> GetBookingAsync()
        {
            return await _onsDbContext.Bookings.AsNoTracking().ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _onsDbContext.Bookings.AsNoTracking()
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<Booking?> UpdateBookingAsync(Booking booking)
        {
            _onsDbContext.Bookings.Update(booking);
            await _onsDbContext.SaveChangesAsync();
            return booking;
        }

        public async Task DeleteBookingAsync(Booking booking)
        {
            _onsDbContext.Bookings.Remove(booking);
            await _onsDbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _onsDbContext.SaveChangesAsync();
        }
    }

}
