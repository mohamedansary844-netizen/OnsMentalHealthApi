using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Repository.PostRepo
{
    public interface IPostRepo
    {
        Task<bool> AddPostAsync(Post post);
        Task<bool> DeletePostAsync(int postId);
        Task<bool> UpdatePostAsync(Post post);
        Task<Post?> GetPostByIdAsync(int postId);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<IEnumerable<Post>> GetPostsByTherapistIdAsync(int therapistId);
    }
}
