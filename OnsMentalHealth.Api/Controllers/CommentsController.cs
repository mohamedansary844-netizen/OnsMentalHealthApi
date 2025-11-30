using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnsMentalHealth.BLL.DTOs.BlogsDTO;
using OnsMentalHealth.BLL.DTOs.CommentsDTO;
using OnsMentalHealth.BLL.Manager.CommentsManager;

namespace OnsMentalHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentManager _commentManager;

        public CommentsController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }


        [HttpGet("GetAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentManager.GetAllCommentsAsync();
            return Ok(comments);
        }



        [HttpGet("GetCommentsById/{id}")]
        public async Task<IActionResult> GetCommentsById(int id)
        {
            var comments = await _commentManager.GetCommentByIdAsync(id);
            return Ok(comments);
        }


        [HttpPost("AddComments")]
        public async Task<IActionResult> AddComment(CommentCreateDTO commentCreateDTO)
        {
            var comments = await _commentManager.AddCommentAsync(commentCreateDTO);

            return Ok(comments);
        }

        [HttpDelete("Deletecomments/{id}")]
        public async Task<IActionResult> DeleteComments(int id)
        {
            var result = await _commentManager.DeleteCommentAsync(id);
            return Ok(result);
        }

        [HttpPut("UpdateComments/{id}")]
        public async Task<IActionResult> UpdateComments (int id, CommentUpdateDTO commentUpdateDTO)
        {
            var result = await _commentManager.UpdateCommentAsync(id, commentUpdateDTO);           
            return Ok(result);
        }


    }
}
