using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Repository.PostRepo
{
    public class PostRepo : IPostRepo
    {
        private readonly OnsDbContext _onsDbContext;

        public PostRepo(OnsDbContext onsDbContext)
        {
            _onsDbContext = onsDbContext;
        }
        public async Task<bool> AddPostAsync(Post post)
        {
            await _onsDbContext.Posts.AddAsync(post);
            await _onsDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await _onsDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
            {
                throw new Exception($"Post with ID {postId} not found.");
            }

            _onsDbContext.Posts.Remove(post);
            await _onsDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePostAsync(Post post)
        {
            var existingPost = await _onsDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == post.PostId);

            if (existingPost == null)
            {
                throw new Exception($"Post with ID {post.PostId} not found.");
            }
            existingPost.PostTitle = post.PostTitle;
            existingPost.PostContent = post.PostContent;
            existingPost.ImageUrl = post.ImageUrl;
            existingPost.CreatedAt = post.CreatedAt;
            existingPost.TherapistId = post.TherapistId;
            await _onsDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _onsDbContext.Posts
                                      .Include(p => p.Therapist)
                                      .Include(p => p.Comments)
                                      .Include(p => p.Reactions)
                                      .FirstOrDefaultAsync(p => p.PostId == postId);
        }
        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _onsDbContext.Posts
                                      .Include(p => p.Therapist)
                                      .Include(p => p.Comments)
                                      .Include(p => p.Reactions)
                                      .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTherapistIdAsync(int therapistId)
        {
            return await _onsDbContext.Posts
                                      .Where(p => p.TherapistId == therapistId)
                                      .Include(p => p.Comments)
                                      .Include(p => p.Reactions)
                                      .ToListAsync();
        }
    }
}
