using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Reposatory.Comments
{
    public interface ICommentRepo
    {
        public Task<bool> AddCommentAsync(Comment comment);
        public Task<bool> DeleteCommentAsync(int commentId);
        public Task<Comment> GetCommentByIdAsync(int commentId);
        public Task<IEnumerable<Comment>> GetAllCommentsAsync();
        public Task<bool> UpdateCommentAsync(Comment comment);
    }
}
