using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using GPROMEC.DOMAIN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectosService _service;

        public ProyectosController(IProyectosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool incluirInactivos = false)
        {
            var proyectos = await _service.GetAllAsync(incluirInactivos);
            return Ok(proyectos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proyecto = await _service.GetByIdAsync(id);
            if (proyecto == null) return NotFound();
            return Ok(proyecto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearProyectoDTO proyectoDto)
        {
            var id = await _service.AddAsync(proyectoDto);
            return CreatedAtAction(nameof(GetById), new { id }, new { Id = id, NombreProyecto = proyectoDto.NombreProyecto });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearProyectoDTO proyectoDto)
        {
            await _service.UpdateAsync(proyectoDto, id);
            return NoContent();
        }

        [HttpDelete("logical/{id}")]
        public async Task<IActionResult> DeleteLogically(int id)
        {
            await _service.DeleteLogicallyAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermanently(int id)
        {
            await _service.DeletePermanentlyAsync(id);
            return NoContent();
        }

        [HttpGet("PorCliente/{idCliente}")]
        public async Task<ActionResult<IEnumerable<ProyectoDTO>>> GetProyectosPorCliente(int idCliente)
        {
            var proyectos = await _service.ObtenerProyectosPorCliente(idCliente);

            if (proyectos == null || !proyectos.Any())
            {
                return NotFound(new { message = "No se encontraron proyectos para este cliente." });
            }

            return Ok(proyectos);
        }
    }
}
