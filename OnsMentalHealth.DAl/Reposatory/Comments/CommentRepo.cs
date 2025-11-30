using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Reposatory.Comments
{
    public class CommentRepo : ICommentRepo
    {
        private readonly OnsDbContext _onsDbContext;

        public CommentRepo(OnsDbContext onsDbContext)
        {
            _onsDbContext = onsDbContext;
        }

        public async Task<bool> AddCommentAsync(Comment comment)
        {
            await _onsDbContext.Comments.AddAsync(comment);
            await _onsDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comment = await _onsDbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }
            _onsDbContext.Comments.Remove(comment);
            await _onsDbContext.SaveChangesAsync();
            return true;
           
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
         return await _onsDbContext.Comments.Include(q => q.Therapist).Include(a=> a.User).ToListAsync();

        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            var comment = await  _onsDbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }
            return  comment;
        }

        public async Task<bool> UpdateCommentAsync(Comment comment)
        {

            var existingComment = await _onsDbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == comment.CommentId);

            if (existingComment == null)
            {
                throw new Exception("Comment not found");
            }
            existingComment.Content = comment.Content;
            existingComment.DateTime = comment.DateTime;
            existingComment.UserId = comment.UserId;
            existingComment.TherapistId = comment.TherapistId;
            existingComment.PostId = comment.PostId;
            _onsDbContext.Comments.Update(existingComment);
            await _onsDbContext.SaveChangesAsync();
            return true;
        }
    }
}
