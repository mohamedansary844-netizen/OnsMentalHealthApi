using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Repositories
{

    public class ReactionRepository : IReactionRepository
    {
        private readonly OnsDbContext _context;

        public ReactionRepository(OnsDbContext context)
        {
            _context = context;
        }

        //public async Task<Reaction> GetByIdAsync(int id) =>
        //    await _context.Reactions.FirstOrDefaultAsync(r => r.ReactionId == id);

        //public async Task<IEnumerable<Reaction>> GetAllAsync() =>
        //    await _context.Reactions.ToListAsync();

        //public async Task AddAsync(Reaction reaction) =>
        //    await _context.Reactions.AddAsync(reaction);

        //public void Update(Reaction reaction) =>
        //    _context.Reactions.Update(reaction);

        //public void Delete(Reaction reaction) =>
        //    _context.Reactions.Remove(reaction);

        //public async Task SaveChangesAsync() =>
        //    await _context.SaveChangesAsync();

        public async Task<Reaction> GetByReactionsIdAsync(int id)
        {
            return await _context.Reactions.FirstOrDefaultAsync(r => r.ReactionId == id);
        }

        public async Task<IEnumerable<Reaction>> GetAllReactionsAsync()
        {
           return await _context.Reactions.ToListAsync();
           
        }

        public async Task<bool> AddReactionsAsync(Reaction reaction)
        {
            var result = await _context.Reactions.AddAsync(reaction);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateReactionsAsync( Reaction reaction)
        {
            _context.Reactions.Update(reaction); 
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReactionsAsync(int id)
        {
          var delet=  await _context.Reactions.FirstOrDefaultAsync(d => d.ReactionId == id);
            if (delet==null)
                return false;

            _context.Reactions.Remove(delet);
            await _context.SaveChangesAsync();
            return true;

        }
    }


}
