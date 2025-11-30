using OnsMentalHealthSolution.DAL.Entities;

namespace OnsMentalHealth.DAL.Repository
{
    public interface ITherapistRepo
    {
        Task<List<Therapist>> GetAllAsync(int pageNumber, int pageSize);
        Task<Therapist> GetByIdAsync(int id);
        Task AddAsync(Therapist therapist);
        Task UpdateAsync(Therapist therapist);
        Task DeleteAsync(Therapist therapist);
    }
}