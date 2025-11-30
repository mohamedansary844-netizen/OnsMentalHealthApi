using System;

namespace OnsMentalHealth.BLL.DTOs
{
    public class BookingUpdateDTO
    {
        public string BookingType { get; set; }
        public TimeOnly BookingTime { get; set; }
        public DateOnly BookingDate { get; set; }

        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}
