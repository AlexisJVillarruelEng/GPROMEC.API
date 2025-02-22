using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class CabeceraPermisosController : ControllerBase
    {
        private readonly ICabeceraPermisosService _service;

        public CabeceraPermisosController(ICabeceraPermisosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CabeceraPermisosDTO>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CabeceraPermisosDTO>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CabeceraPermisosDTO>> Create([FromBody] CabeceraPermisosDTO dto)
        {
            // Se ignora el ID que venga en el DTO
            dto.IdCabeceraPermisos = 0;
            var createdDto = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdDto.IdCabeceraPermisos }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CabeceraPermisosDTO dto)
        {
            if (id != dto.IdCabeceraPermisos)
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo del DTO.");

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
