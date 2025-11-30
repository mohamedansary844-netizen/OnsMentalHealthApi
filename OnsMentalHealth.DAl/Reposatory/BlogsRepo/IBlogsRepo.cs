using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Reposatory.BlogsRepo
{
    public interface IBlogsRepo
    {
        // Get all
        public Task<IEnumerable<Blog>> GetAllBlogsAsync();
        // Get by id
        public Task<Blog> GetBlogByIdAsync(int id);
        // Add 
        public Task<bool> AddBlogAsync(Blog blog);
        // Update
        public Task<bool> UpdateBlogAsync(Blog blog);
        // Delete
        public Task<bool> DeleteBlogAsync(int id);
    }
}
