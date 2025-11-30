using OnsMentalHealth.BLL.DTOs.PostsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.PostManager
{
    public interface IPostManager
    {
        public Task<IEnumerable<PostReadDTO>> GetAllPostsAsync();
        public Task<PostReadDTO?> GetPostByIdAsync(int postId);
        public Task<string> AddPostAsync(PostAddDTO postAddDTO);
        public Task<string> UpdatePostAsync(int postId, PostUpdateDTO postUpdateDTO);
        public Task<string> DeletePostAsync(int postId);
        public Task<IEnumerable<PostReadDTO>> GetPostsByTherapistIdAsync(int therapistId);
    }
}
