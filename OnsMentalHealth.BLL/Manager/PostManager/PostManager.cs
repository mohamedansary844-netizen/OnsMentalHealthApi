using OnsMentalHealth.BLL.DTOs.PostsDTO;
using OnsMentalHealth.DAl.Repository.PostRepo;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.PostManager
{
    public class PostManager : IPostManager
    {
        private readonly IPostRepo _postRepo;

        public PostManager(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<string> AddPostAsync(PostAddDTO postAddDTO)
        {
            var newPost = new Post
            {
                PostTitle = postAddDTO.PostTitle,
                PostContent = postAddDTO.PostContent,
                ImageUrl = postAddDTO.ImageUrl,
                TherapistId = postAddDTO.TherapistId,
                CreatedAt = DateTime.UtcNow
            };
            var isAdded = await _postRepo.AddPostAsync(newPost);

            return isAdded ? "Post Added Successfully" : "Failed to Add Post";
        }
        public async Task<string> DeletePostAsync(int postId)
        {
            var post = await _postRepo.GetPostByIdAsync(postId);
            if (post == null)
                return "Post Not Found";

            await _postRepo.DeletePostAsync(postId);
            return "Post Deleted Successfully";
        }

        public async Task<IEnumerable<PostReadDTO>> GetAllPostsAsync()
        {
            var posts = await _postRepo.GetAllPostsAsync();

            var postDTOs = posts.Select(p => new PostReadDTO
            {
                PostId = p.PostId,
                PostTitle = p.PostTitle,
                PostContent = p.PostContent,
                ImageUrl = p.ImageUrl,
                CreatedAt = p.CreatedAt,
                TherapistId = p.TherapistId,
                TherapistName = p.Therapist?.User?.UserName,
            });
            return postDTOs;
        }

        public async Task<PostReadDTO?> GetPostByIdAsync(int postId)
        {
            var post = await _postRepo.GetPostByIdAsync(postId);
            if (post == null)
                return null;

            var postDTO = new PostReadDTO
            {
                PostId = postId,
                PostTitle = post.PostTitle,
                PostContent = post.PostContent,
                ImageUrl = post.ImageUrl,
                CreatedAt = post.CreatedAt,
                TherapistId = post.TherapistId,
                TherapistName = post.Therapist?.User?.UserName,
            };
            return postDTO;
        }

        public async Task<string> UpdatePostAsync(int postId, PostUpdateDTO postUpdateDTO)
        {
            if (postId != postUpdateDTO.PostId)
            {
                return "ID mismatch between route and request body.";
            }

            var existingPost = await _postRepo.GetPostByIdAsync(postId);
            if (existingPost == null)
                return "Post Not Found";

            existingPost.PostTitle = postUpdateDTO.PostTitle;
            existingPost.PostContent = postUpdateDTO.PostContent;
            existingPost.ImageUrl = postUpdateDTO.ImageUrl;
            existingPost.TherapistId = postUpdateDTO.TherapistId;

            await _postRepo.UpdatePostAsync(existingPost);
            return "Post Updated Successfully";
        }

        public async Task<IEnumerable<PostReadDTO>> GetPostsByTherapistIdAsync(int therapistId)
        {
            var posts = await _postRepo.GetPostsByTherapistIdAsync(therapistId);

            var postDTOs = posts.Select(p => new PostReadDTO
            {
                PostId = p.PostId,
                PostTitle = p.PostTitle,
                PostContent = p.PostContent,
                ImageUrl = p.ImageUrl,
                CreatedAt = p.CreatedAt,
                TherapistId = p.TherapistId,
                TherapistName = p.Therapist?.User?.UserName,
            });
            return postDTOs;
        }
    }
}