using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.DTOs.CommentsDTO
{
    public class CommentCreateDTO
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public int TherapistId { get; set; }
        public int PostId { get; set; }

    }
}
