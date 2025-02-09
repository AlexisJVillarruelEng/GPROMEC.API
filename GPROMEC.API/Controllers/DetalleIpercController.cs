using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class DetalleIPERCController : ControllerBase
    {
        private readonly IDetalleIpercService _service;

        public DetalleIPERCController(IDetalleIpercService service)
        {
            _service = service; // Inyección del servicio.
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Obtiene todos los registros.
            var detalles = await _service.GetAllAsync();
            return Ok(detalles); // Retorna los registros en formato JSON.
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Obtiene un registro por su ID.
            var detalle = await _service.GetByIdAsync(id);
            if (detalle == null) return NotFound(); // Retorna 404 si no se encuentra.
            return Ok(detalle); // Retorna el registro.
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearDetalleIpercDTO dto)
        {
            // Crea un nuevo registro.
            var id = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id); // Retorna 201 con el ID generado.
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearDetalleIpercDTO dto)
        {
            // Actualiza un registro existente.
            await _service.UpdateAsync(id, dto);
            return NoContent(); // Retorna 204 si se actualiza correctamente.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Elimina un registro por su ID.
            await _service.DeleteAsync(id);
            return NoContent(); // Retorna 204 si se elimina correctamente.
        }
        [HttpGet("PorTarea/{idTarea}")]
        public async Task<ActionResult<IEnumerable<DetalleIperc>>> GetDetallesPorTarea(int idTarea)
        {
            var detalles = await _service.ObtenerDetallesPorTarea(idTarea);

            if (detalles == null || !detalles.Any())
            {
                return NotFound(new { message = "No se encontraron detalles para esta tarea." });
            }

            return Ok(detalles);
        }
    }
}
