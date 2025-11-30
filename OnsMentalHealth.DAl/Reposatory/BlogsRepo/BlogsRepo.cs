using Microsoft.EntityFrameworkCore;
using OnsMentalHealthSolution.DAL.Context;
using OnsMentalHealthSolution.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OnsMentalHealth.DAl.Reposatory.BlogsRepo
{
    public class BlogsRepo : IBlogsRepo
    {
        private readonly OnsDbContext _onsDbContext;

        public BlogsRepo(OnsDbContext onsDbContext ) 
        {
            _onsDbContext = onsDbContext;
        }

        public async Task<bool> AddBlogAsync(Blog blog)
        {
            await _onsDbContext.Blogs.AddAsync(blog);
            await _onsDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var blog = await _onsDbContext.Blogs.FindAsync(id);

            if (blog == null)
                return false;

            _onsDbContext.Blogs.Remove(blog);
            await _onsDbContext.SaveChangesAsync();
            return true;
        }
    


        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
        return  await _onsDbContext.Blogs.ToListAsync();
        }


        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _onsDbContext.Blogs.FirstOrDefaultAsync(b => b.BlogId == id);
        }


        // we work on Entity not DTO
        public async Task<bool> UpdateBlogAsync(Blog updatedBlog)
        {
            var existingBlog = await _onsDbContext.Blogs.FindAsync(updatedBlog.BlogId);

            if (existingBlog == null)
                return false;

            existingBlog.Title = updatedBlog.Title;
            existingBlog.ContentUrl = updatedBlog.ContentUrl;
            existingBlog.TherapistId = updatedBlog.TherapistId;
            existingBlog.Date = updatedBlog.Date;

            await _onsDbContext.SaveChangesAsync();
            return true;
        }
    }
}
