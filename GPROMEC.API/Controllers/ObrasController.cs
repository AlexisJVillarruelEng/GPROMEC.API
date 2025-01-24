using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private readonly IObrasService _service;

        public ObrasController(IObrasService service)
        {
            _service = service; // Inyección del servicio.
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var obras = await _service.GetAllAsync();
            return Ok(obras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obra = await _service.GetByIdAsync(id);
            if (obra == null) return NotFound();
            return Ok(obra);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CrearObraDTO obraDto)
        {
            var id = await _service.AddAsync(obraDto);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearObraDTO obraDto)
        {
            await _service.UpdateAsync(obraDto, id);
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
