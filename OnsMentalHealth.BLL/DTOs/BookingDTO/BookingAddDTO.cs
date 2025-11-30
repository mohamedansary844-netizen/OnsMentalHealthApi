using System;

namespace OnsMentalHealth.BLL.DTOs
{
    public class BookingAddDTO
    {
        public string BookingType { get; set; }
        public DateOnly BookingDate { get; set; }
        public TimeOnly BookingTime { get; set; }
        public string? ImageUrl { get; set; }

        public int TherapistId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}
