using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using OnsMentalHealthSolution.DAL.Entities; 
using OnsMentalHealth.DAL.Repository;       
using OnsMentalHealth.BLL.DTOs.Therapists;  
namespace OnsMentalHealth.BLL.Manager
{
    public class TherapistManager : ITherapistManager
    {
        private readonly ITherapistRepo _repo;
        private readonly UserManager<User> _userManager;
        private readonly IMemoryCache _cache;


        public TherapistManager(ITherapistRepo repo, UserManager<User> userManager, IMemoryCache cache)
        {
            _repo = repo;
            _userManager = userManager;
            _cache = cache;
        }

        // 1. Get All 
        public async Task<List<TherapistReadDTO>> GetAllTherapistsAsync(int pageNumber, int pageSize)
        {
           
            string cacheKey = $"Therapists_Page{pageNumber}_Size{pageSize}";

            
            if (!_cache.TryGetValue(cacheKey, out List<TherapistReadDTO> cachedList))
            {
                var therapists = await _repo.GetAllAsync(pageNumber, pageSize);

                cachedList = therapists.Select(t => new TherapistReadDTO
                {
                    Id = t.TherapistId,
                    FullName = t.User != null ? t.User.UserName : "Unknown",
                    Email = t.User != null ? t.User.Email : "Unknown",
                    Specialization = t.Speclization,
                    City = t.City,
                    Gender = t.Gender
                }).ToList();

                
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                
                _cache.Set(cacheKey, cachedList, cacheOptions);
            }

         
            return cachedList;
        }

        // 2. Get By Id
        public async Task<TherapistReadDTO> GetTherapistByIdAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return null;

            return new TherapistReadDTO
            {
                Id = t.TherapistId,
                FullName = t.User != null ? t.User.UserName : "Unknown",
                Email = t.User != null ? t.User.Email : "Unknown",
                Specialization = t.Speclization,
                City = t.City,
                Gender = t.Gender
            };
        }

        // 3. Add 
        public async Task<TherapistReadDTO> AddTherapistAsync(TherapistAddDTO addDto)
        {
            
            DateOnly birthdayDateOnly = DateOnly.FromDateTime(addDto.Birthday);

            
            var user = new User
            {
                UserName = $"{addDto.FirstName}{addDto.LastName}", 
                Email = addDto.Email,
                Gender = addDto.Gender,
                Birthday = birthdayDateOnly
            };

            
            var result = await _userManager.CreateAsync(user, addDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create user: {errors}");
            }
            var therapist = new Therapist
            {
                UserId = user.Id, 
                Speclization = addDto.Specialization,
                City = addDto.City,
                Gender = addDto.Gender,
            };
            await _repo.AddAsync(therapist);
            return new TherapistReadDTO
            {
                Id = therapist.TherapistId,
                FullName = user.UserName,
                Email = user.Email,
                Specialization = therapist.Speclization,
                City = therapist.City,
                Gender = therapist.Gender
            };
        }

        // 4. Update
        public async Task<bool> UpdateTherapistAsync(int id, TherapistUpdateDTO updateDto)
        {
            var therapist = await _repo.GetByIdAsync(id);
            if (therapist == null) return false;

            // تحديث بيانات الدكتور
            therapist.Speclization = updateDto.Specialization;
            therapist.City = updateDto.City;

            await _repo.UpdateAsync(therapist);
            return true;
        }

        // 5. Delete
        public async Task<bool> DeleteTherapistAsync(int id)
        {
            var therapist = await _repo.GetByIdAsync(id);
            if (therapist == null) return false;

            
            await _repo.DeleteAsync(therapist);
            await _userManager.DeleteAsync(therapist.User);

            return true;
        }
    }
}