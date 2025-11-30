using OnsMentalHealth.BLL.DTOs.CommentsDTO;
using OnsMentalHealth.DAl.Reposatory.Comments;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.CommentsManager
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentRepo _commentRepo;

        public CommentManager(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public async Task<string> AddCommentAsync(CommentCreateDTO commentCreateDTO)
        {
            var newComment = new Comment
            {
                Content = commentCreateDTO.Content,
                TherapistId = commentCreateDTO.TherapistId,
                UserId = commentCreateDTO.UserId,
                PostId = commentCreateDTO.PostId,
            };
            var isAdded = await _commentRepo.AddCommentAsync(newComment);
            return isAdded ? "Comment Added Successfully" : "Failed to Add Comment";

           
        }

        public async Task<string> DeleteCommentAsync(int commentId)
        {
            var comment = await _commentRepo.GetCommentByIdAsync(commentId);
            if (comment == null)
                return "Comment Not Found";
            await _commentRepo.DeleteCommentAsync(commentId);
            return "Comment Deleted Successfully";
        }

        public async Task<IEnumerable<CommentReadDTO>> GetAllCommentsAsync()
        {
             var comments = await _commentRepo.GetAllCommentsAsync();
            var commentDTOs = comments.Select(c => new CommentReadDTO
            {
                CommentId = c.CommentId,
                Content = c.Content,
                TherapistId = c.TherapistId,
                UserId = c.UserId,
                PostId = c.PostId,
                CreatedAt = c.DateTime
            });
            return commentDTOs;
        }

        public async Task<CommentReadDTO> GetCommentByIdAsync(int commentid)
        {
            var comment = await  _commentRepo.GetCommentByIdAsync(commentid);
            if (comment == null)
                return null;

            var commentDTO = new CommentReadDTO
            {
                CommentId = commentid,
                Content = comment.Content,
                TherapistId = comment.TherapistId,
                UserId = comment.UserId,
                PostId = comment.PostId,
                CreatedAt = comment.DateTime
            };
            return commentDTO;
           
        }

        public async Task<string> UpdateCommentAsync(int commentId, CommentUpdateDTO commentUpdateDTO)
        {
            var existingComment = await _commentRepo.GetCommentByIdAsync(commentId);
            if (existingComment == null)
                return "Comment Not Found";

            existingComment.Content = commentUpdateDTO.Content;
            existingComment.TherapistId = commentUpdateDTO.TherapistId;
            existingComment.UserId = commentUpdateDTO.UserId;
            existingComment.PostId = commentUpdateDTO.PostId;

            await _commentRepo.UpdateCommentAsync(existingComment);
            return "Comment Updated Successfully";
        }

    }
}
