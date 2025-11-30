using OnsMentalHealth.BLL.DTOs.CommentsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.CommentsManager
{
    public interface ICommentManager
    {
        public Task<IEnumerable<CommentReadDTO>> GetAllCommentsAsync();
        public Task<CommentReadDTO> GetCommentByIdAsync(int commentid);
        public Task<string> AddCommentAsync(CommentCreateDTO commentCreateDTO);
        public Task<string> UpdateCommentAsync(int commentId, CommentUpdateDTO commentUpdateDTO);
        public Task<string> DeleteCommentAsync(int commentId);
    }
}
