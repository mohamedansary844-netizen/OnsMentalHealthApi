using OnsMentalHealth.BLL.DTOs;
using OnsMentalHealth.DAl.Repositories;
using OnsMentalHealthSolution.DAL.Entities;
using AutoMapper;

namespace OnsMentalHealth.BLL.Services
{
    public class ReactionService : IReactionService
    {
        private readonly IReactionRepository _repo;
        private readonly IMapper _mapper;

        public ReactionService(IReactionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        ////  Get all 
        //public async Task<IEnumerable<ReactionResponseDto>> GetAllAsync()
        //{
        //    var reactions = await _repo.GetAllAsync();
        //    return _mapper.Map<IEnumerable<ReactionResponseDto>>(reactions);
        //}

        //// Get reaction by ID
        //public async Task<ReactionResponseDto> GetByIdAsync(int id)
        //{
        //    var reaction = await _repo.GetByIdAsync(id);
        //    return reaction == null ? null : _mapper.Map<ReactionResponseDto>(reaction);
        //}

        ////  Add 
        //public async Task<ReactionResponseDto> AddAsync(CreateReactionDto dto)
        //{
        //    var existing = (await _repo.GetAllAsync())
        //                   .FirstOrDefault(r => r.UserId == dto.UserId
        //                                     && r.TherapistId == dto.TherapistId);

        //    if (existing != null)
        //    {
        //        existing.Love = dto.Love;
        //        existing.Angry = dto.Angry;
        //        existing.Like = dto.Like;

        //        _repo.Update(existing);
        //        await _repo.SaveChangesAsync();
        //        return _mapper.Map<ReactionResponseDto>(existing);
        //    }

          
        //    var reaction = _mapper.Map<Reaction>(dto);
        //    await _repo.AddAsync(reaction);
        //    await _repo.SaveChangesAsync();
        //    return _mapper.Map<ReactionResponseDto>(reaction);
        //}

        //// Update reaction by ID
        //public async Task<ReactionResponseDto> UpdateAsync(int id, UpdateReactionDto dto)
        //{
        //    var existing = await _repo.GetByIdAsync(id);
        //    if (existing == null) return null;

        //    _mapper.Map(dto, existing);
        //    _repo.Update(existing);
        //    await _repo.SaveChangesAsync();
        //    return _mapper.Map<ReactionResponseDto>(existing);
        //}

        ////  Delete reaction by ID
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var existing = await _repo.GetByIdAsync(id);
        //    if (existing == null) return false;

        //    _repo.Delete(existing);
        //    await _repo.SaveChangesAsync();
        //    return true;
        //}

        async Task<string> IReactionService.AddAsync(CreateReactionDto createReactionDto)
        {
            var reaction =await _repo.AddReactionsAsync(_mapper.Map<Reaction>(createReactionDto));
            if (reaction)
                return "Reaction added successfully.";
            else
                return "Failed to add reaction.";

        }

        async Task<string> IReactionService.UpdateAsync(int id, UpdateReactionDto updateReactionDto)
        {
            var existingTask = await _repo.GetByReactionsIdAsync(id);
            if (existingTask == null)
                return "Reaction not found.";

            _mapper.Map(updateReactionDto, existingTask);
            await _repo.UpdateReactionsAsync(existingTask);
            return "Reaction updated successfully.";
        }

        async Task<string> IReactionService.DeleteAsync(int id)
        {
            var existing = await _repo.GetByReactionsIdAsync(id);
            if (existing == null) 
                return "Reaction not found.";
            await _repo.DeleteReactionsAsync(id);
            return "Reaction deleted successfully.";


        }

        public async Task<IEnumerable<ReactionResponseDto>> GetAllAsync()
        {
            var reactions = await _repo.GetAllReactionsAsync();
            return _mapper.Map<IEnumerable<ReactionResponseDto>>(reactions);
        }

        public async Task<ReactionResponseDto> GetByIdAsync(int id)
        {
            var reaction = await _repo.GetByReactionsIdAsync(id);
            return reaction == null ? null : _mapper.Map<ReactionResponseDto>(reaction);
        }


    }

}
