using System;
using System.ComponentModel.DataAnnotations;

namespace OnsMentalHealth.BLL.DTOs.Therapists
{
    public class TherapistAddDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Specialization { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}