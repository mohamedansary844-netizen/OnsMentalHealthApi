using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnsMentalHealth.BLL.DTOs.PostsDTO;
using OnsMentalHealth.BLL.Manager.PostManager;
namespace OnsMentalHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostManager _postManager;

        public PostsController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postManager.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("GetPostById/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postManager.GetPostByIdAsync(id);
            return Ok(post);
        }

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost(PostAddDTO postAddDTO)
        {
            var result = await _postManager.AddPostAsync(postAddDTO);
            return Ok(result);
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _postManager.DeletePostAsync(id);
            return Ok(result);
        }

        [HttpPut("UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostUpdateDTO postUpdateDTO)
        {
            var result = await _postManager.UpdatePostAsync(id, postUpdateDTO);
            return Ok(result);
        }
    }
}
