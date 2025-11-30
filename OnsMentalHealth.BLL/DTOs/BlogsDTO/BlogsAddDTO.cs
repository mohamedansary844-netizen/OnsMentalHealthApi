using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.DTOs.BlogsDTO
{
    public class BlogsAddDTO
    {
        public string Title { get; set; }
        public string ContentUrl { get; set; }
        public int TherapistId { get; set; }
        public DateTime? DateTime { get; set; }

    }
}
