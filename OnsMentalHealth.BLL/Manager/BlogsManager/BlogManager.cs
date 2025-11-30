using OnsMentalHealth.BLL.DTOs.BlogsDTO;
using OnsMentalHealth.DAl.Reposatory.BlogsRepo;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.BLL.Manager.BlogsManager
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogsRepo _bolgsRepo;

        public BlogManager(IBlogsRepo bolgsRepo  ) 
        {
            _bolgsRepo = bolgsRepo;
        }

        public async Task<string> AddBlogAsync(BlogsAddDTO blogsAddDTO)
        {
            var newblog = new Blog
            {

                Title = blogsAddDTO.Title,
                TherapistId = blogsAddDTO.TherapistId,
                ContentUrl = blogsAddDTO.ContentUrl,
                Date = blogsAddDTO?.DateTime

              
            };
          
             var result =  await _bolgsRepo.AddBlogAsync(newblog);
            return result ? "Blog Added Successfully" : "Failed to Add Blog";
        }

        public async Task<string> DeleteBlogAsync(int id)
        {

            var blog = await _bolgsRepo.GetBlogByIdAsync(id);
            if (blog == null)
                return "Blog Not Found";
            var result = await _bolgsRepo.DeleteBlogAsync(id);
            return result ? "Blog Deleted Successfully" : "Failed to Delete Blog";           
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
          return await  _bolgsRepo.GetAllBlogsAsync();
           

        }

        public async Task<Blog> GetBlogsByIdAsync(int id)
        {
            return await _bolgsRepo.GetBlogByIdAsync(id);
        }

        public async Task<string?> UpdateBlogeAsync(int id, BlogUpdateDTO blogUpdateDTO)
        {
            var blog = await _bolgsRepo.GetBlogByIdAsync(id);
            if (blog == null)
                return "Blog Not Found";

           blog.Title = blogUpdateDTO.Title;
            blog.TherapistId = blogUpdateDTO.TherapistId;
            blog.ContentUrl = blogUpdateDTO.ContentUrl;
            blog.Date = blogUpdateDTO?.Date;

            var result = await _bolgsRepo.UpdateBlogAsync(blog);
            return result ? "Blog Updated Successfully" : "Failed to Update Blog";

        }
    }
}
