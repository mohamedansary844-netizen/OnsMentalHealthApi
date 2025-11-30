using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Booking
    {

        public int BookingId { get; set; }
        public string BookingType { get; set; }
        public TimeOnly BookingTime { get; set; }
        public DateOnly BookingDate { get; set; }
        public string Status { get; set; } // (Pending/Confirmed/Cancelled)
        public string? ImageUrl { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public int TherapistId { get; set; }

        public User? User { get; set; }
        public Therapist? Therapist { get; set; }

    }
}


