using OnsMentalHealth.BLL.DTOs.Therapists;

namespace OnsMentalHealth.BLL.Manager
{
    public interface ITherapistManager
    {
        Task<List<TherapistReadDTO>> GetAllTherapistsAsync(int pageNumber, int pageSize);
        Task<TherapistReadDTO> GetTherapistByIdAsync(int id);
        Task<TherapistReadDTO> AddTherapistAsync(TherapistAddDTO addDto);
        Task<bool> UpdateTherapistAsync(int id, TherapistUpdateDTO updateDto);
        Task<bool> DeleteTherapistAsync(int id);
    }
}