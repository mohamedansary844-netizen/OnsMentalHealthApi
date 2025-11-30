using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnsMentalHealth.BLL.DTOs;


namespace OnsMentalHealth.BLL.Services
{
    public interface IReactionService
    {
        Task<IEnumerable<ReactionResponseDto>> GetAllAsync();
        Task<ReactionResponseDto> GetByIdAsync(int id);
        Task<string> AddAsync(CreateReactionDto createReactionDto);
        Task<string> UpdateAsync(int id, UpdateReactionDto updateReactionDto);
        Task<string> DeleteAsync(int id);
    }
}
