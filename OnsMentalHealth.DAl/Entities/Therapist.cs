using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Therapist 
    {
            public int TherapistId { get; set; }
            [ForeignKey("User")]
            public string UserId { get; set; }
            public User User { get; set; } 
            public string Speclization { get; set; }
            public string City { get; set; }
            public DateTime Birthday { get; set; }
            public string Gender { get; set; }
            
            public string? Image { get; set; }

        public List<Comment> comments { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public List<Post> posts { get; set; }
        public List<Reaction> Reactions { get; set; }
        public List<Blog> Blogs { get; set; } 

    }
}
