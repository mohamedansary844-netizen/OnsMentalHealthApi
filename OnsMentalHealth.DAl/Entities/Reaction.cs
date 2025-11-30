using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Reaction
    {
        public int ReactionId { get; set; }

        public bool Love { get; set; }
        public bool Angry { get; set; }
        public bool Like { get; set; }

        public string UserId { get; set; }
        public int TherapistId { get; set; }

        public User User { get; set; }
        public Therapist Therapist { get; set; }

    }
}
