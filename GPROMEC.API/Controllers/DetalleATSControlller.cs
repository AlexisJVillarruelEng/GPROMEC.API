using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class DetalleAtsController : ControllerBase
    {
        private readonly IDetalleATSService _service;

        public DetalleAtsController(IDetalleATSService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetalleAtsCreateUpdateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.IdDetalleAts }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _service.GetAllAsync();
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DetalleAtsCreateUpdateDto dto)
        {
            if (dto == null)
                return BadRequest();

            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
