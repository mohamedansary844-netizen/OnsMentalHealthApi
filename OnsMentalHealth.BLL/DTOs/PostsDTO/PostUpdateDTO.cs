using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.DTOs.PostsDTO
{
    public class PostUpdateDTO
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string ImageUrl { get; set; }
        public int TherapistId { get; set; }
    }
}
