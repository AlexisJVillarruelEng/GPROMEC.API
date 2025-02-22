using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class RespuestaPermisosController : ControllerBase
    {
        private readonly IRespuestaPermisosService _service;
        public RespuestaPermisosController(IRespuestaPermisosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permisos = await _service.GetAllAsync();
            return Ok(permisos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permiso = await _service.GetByIdAsync(id);
            if (permiso == null)
                return NotFound();
            return Ok(permiso);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RespuestaPermisosDTO dto)
        {
            if (dto == null)
                return BadRequest("El dto es requerido.");
            // Aseguramos que el Id se ponga en 0 para que se genere automáticamente
            dto.IdRespuesta = 0;
            var result = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.IdRespuesta }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RespuestaPermisosDTO dto)
        {
            if (dto == null)
                return BadRequest("El dto es requerido.");
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
