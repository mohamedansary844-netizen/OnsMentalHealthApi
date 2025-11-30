using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Repositories
{
    public interface IReactionRepository
    {
        Task<Reaction> GetByReactionsIdAsync(int id);
        Task<IEnumerable<Reaction>> GetAllReactionsAsync();
        Task<bool> AddReactionsAsync(Reaction reaction);
        Task<bool> UpdateReactionsAsync( Reaction reaction);
        Task<bool> DeleteReactionsAsync(int id);
    }
}
