using OnsMentalHealth.BLL.DTOs.BlogsDTO;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.BlogsManager
{
    public interface IBlogManager
    {
        public Task<IEnumerable<Blog>> GetAllBlogsAsync();
        public Task<Blog> GetBlogsByIdAsync(int id);
        public Task<string> AddBlogAsync(BlogsAddDTO blogsAddDTO);
        public Task<string> DeleteBlogAsync(int id);
        public Task<string> UpdateBlogeAsync(int id, BlogUpdateDTO blogUpdateDTO);
    }
}
