using Microsoft.AspNetCore.Mvc;
using OnsMentalHealth.BLL.DTOs.Therapists;
using OnsMentalHealth.BLL.Manager;

namespace OnsMentalHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapistController : ControllerBase
    {
        private readonly ITherapistManager _manager;

        public TherapistController(ITherapistManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _manager.GetAllTherapistsAsync(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _manager.GetTherapistByIdAsync(id);
            if (result == null) return NotFound("Therapist not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TherapistAddDTO dto)
        {
            return Ok(await _manager.AddTherapistAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TherapistUpdateDTO dto)
        {
            var result = await _manager.UpdateTherapistAsync(id, dto);
            if (!result) return NotFound("Therapist not found");
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manager.DeleteTherapistAsync(id);
            if (!result) return NotFound("Therapist not found");
            return Ok("Deleted Successfully");
        }
    }
}