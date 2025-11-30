using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealthSolution.DAL.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public DateTime? Date { get; set; }

        public string ContentUrl { get; set; }
        public int TherapistId { get; set; }
        public Therapist Therapist { get; set; } 
    }
}
