using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisoService _service;
        public PermisosController(IPermisoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermisoDto dto)
        {
            // Se ignora el id enviado en dto (si viene) ya que no se requiere para POST
            dto.IdPermiso = 0;
            var creado = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.IdPermiso }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PermisoDto dto)
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
