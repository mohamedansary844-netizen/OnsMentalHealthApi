using Microsoft.AspNetCore.Mvc;
using OnsMentalHealth.BLL.Services;
using OnsMentalHealthSolution.DAL.Entities;
using OnsMentalHealth.BLL.DTOs;

namespace OnsMentalHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _service;

        public ReactionController(IReactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reaction = await _service.GetByIdAsync(id);
            if (reaction == null) return NotFound();
            return Ok(reaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReactionDto dto) =>
            Ok(await _service.AddAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateReactionDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result == "Not Found") return NotFound();
            return Ok(result);
           
        }
    }

}
