using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public DateTime DateTime { get; set; }
        public string Content { get; set; } 

        public string UserId { get; set; }
        public User User { get; set; }

        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
