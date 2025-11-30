namespace OnsMentalHealth.BLL.DTOs.Therapists
{
    public class TherapistReadDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
    }
}