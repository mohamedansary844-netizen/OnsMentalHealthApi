using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.DTOs.BlogsDTO
{
    public class BlogUpdateDTO
    {

        public string Title { get; set; }

        public DateTime? Date { get; set; }

        public string ContentUrl { get; set; }
        public int TherapistId { get; set; }
    }
}
