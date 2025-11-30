using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnsMentalHealth.BLL.DTOs.BlogsDTO;
using OnsMentalHealth.BLL.Manager.BlogsManager;
using OnsMentalHealthSolution.DAL.Entities;

namespace OnsMentalHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogManager _blogManager;

        public BlogsController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

      //  [Authorize(Roles = "Admin")] // [Authorize filter 

        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _blogManager.GetAllBlogsAsync();
            return Ok(blogs);
        }


        [Authorize(Roles = "Admin")] // [Authorize filter 

        [HttpGet("GetBlogsById/{id}")]
        public async Task<IActionResult> GetBlogsById(int id)
        {
            var blog = await _blogManager.GetBlogsByIdAsync(id);

            if (blog == null)
                return NotFound("Blog not found");

            return Ok(blog);
        }

        [Authorize(Roles = "Therapist")] // [Authorize filter 


        [HttpPost("AddBlog")]
        public async Task<IActionResult> AddBlog(BlogsAddDTO blogsAddDTO)
        {
            var blog = await _blogManager.AddBlogAsync(blogsAddDTO);
            
            return Ok("Added Successfully");
        }

        [Authorize(Roles = "Therapist")] // [Authorize filter 


        [HttpDelete("DeleteBlog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await _blogManager.DeleteBlogAsync(id);

            if (result == "Blog Not Found")
                return NotFound(result);

            return Ok(result);
        }

        [Authorize(Roles = "Therapist")] // [Authorize filter 

        [HttpPut("UpdateBlog/{id}")]
        public async Task<IActionResult> UpdateBlog(int id, BlogUpdateDTO dto)
        {
            var result = await _blogManager.UpdateBlogeAsync(id, dto);

            if (result == null)
                return NotFound("Blog not found");

            return Ok(result);
        }

    }
}
