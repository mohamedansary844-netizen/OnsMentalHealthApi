using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;


namespace OnsMentalHealth.DAL.Repository
{
    public class TherapistRepo : ITherapistRepo
    {
        private readonly OnsDbContext _context;

        public TherapistRepo(OnsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Therapist>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Therapists
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Therapist> GetByIdAsync(int id)
        {
            return await _context.Therapists.FindAsync(id);
        }

        public async Task AddAsync(Therapist therapist)
        {
            await _context.Therapists.AddAsync(therapist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Therapist therapist)
        {
            _context.Therapists.Update(therapist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Therapist therapist)
        {
            _context.Therapists.Remove(therapist);
            await _context.SaveChangesAsync();
        }
    }
}