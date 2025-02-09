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
    public class ProcesosController : ControllerBase
    {
        private readonly IProcesosService _service;

        public ProcesosController(IProcesosService service)
        {
            _service = service; // Inyección del servicio.
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var procesos = await _service.GetAllAsync();
            return Ok(procesos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proceso = await _service.GetByIdAsync(id);
            if (proceso == null) return NotFound();
            return Ok(proceso);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CrearProcesoDTO dto)
        {
            var id = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearProcesoDTO dto)
        {
            await _service.UpdateAsync(dto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("PorPartida/{idPartida}")]
        public async Task<ActionResult<IEnumerable<Procesos>>> GetProcesosPorPartida(int idPartida)
        {
            var procesos = await _service.ObtenerProcesosPorPartida(idPartida);

            if (procesos == null || !procesos.Any())
            {
                return NotFound(new { message = "No se encontraron procesos para esta partida." });
            }

            return Ok(procesos);
        }
    }
}
