using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class DetallePermisosGeneralController : ControllerBase
    {
        private readonly IDetallePermisosGeneralService _service;

        public DetallePermisosGeneralController(IDetallePermisosGeneralService service)
        {
            _service = service;
        }

        // GET: api/DetallePermisosGeneral
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePermisosGeneral>>> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(dtos);
        }

        // GET: api/DetallePermisosGeneral/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePermisosGeneral>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        // POST: api/DetallePermisosGeneral
        [HttpPost]
        public async Task<ActionResult<DetallePermisoGeneral>> Create([FromBody] DetallePermisoGeneral dto)
        {
            var createdDto = await _service.AddAsync(dto);
            // Devuelve un 201 Created con el DTO completo
            return CreatedAtAction(nameof(GetById), new { id = createdDto.IdDetalle }, createdDto);
        }

        // PUT: api/DetallePermisosGeneral/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetallePermisoGeneral dto)
        {
            if (id != dto.IdDetalle)
                return BadRequest("El ID del URL no coincide con el ID del cuerpo de la solicitud.");

            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE: api/DetallePermisosGeneral/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
