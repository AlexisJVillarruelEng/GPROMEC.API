using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class FirmasController : ControllerBase
    {
        private readonly IFirmasMatrizIperService _service;

        public FirmasController(IFirmasMatrizIperService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var firmas = await _service.GetAllAsync();
            return Ok(firmas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var firma = await _service.GetByIdAsync(id);
            if (firma == null) return NotFound();
            return Ok(firma);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearFirmaDTO firmaDto)
        {
            var result = await _service.CreateAsync(firmaDto);
            // Responde con los datos de los firmantes y las fechas
            return CreatedAtAction(nameof(GetById), new { id = result.IdFirma }, new
            {
                Id = result.IdFirma,
                ElaboradoPor = result.NombreElaboradoPor,
                FechaElaborado = result.FechaElaborado,
                RevisadoPor = result.NombreRevisadoPor,
                FechaRevisado = result.FechaRevisado,
                AprobadoPor = result.NombreAprobadoPor,
                FechaAprobado = result.FechaAprobado
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActualizarFirmaDTO firmaDto)
        {
            var result = await _service.UpdateAsync(id, firmaDto);
            if (result == null) return NotFound();
            return Ok(new
            {
                ElaboradoPor = result.NombreElaboradoPor,
                FechaActualizadoElaborado = result.FechaElaborado,
                RevisadoPor = result.NombreRevisadoPor,
                FechaActualizadoRevisado = result.FechaRevisado,
                AprobadoPor = result.NombreAprobadoPor,
                FechaActualizadoAprobado = result.FechaAprobado
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok(new { message = "Firma eliminada correctamente", FechaEliminacion = DateTime.UtcNow });
        }

        [HttpGet("Matriz/{id_partida}")]
        public async Task<IActionResult> ObtenerFirmasPorMatriz(int id_partida)
        {
            try
            {
                var firmas = await _service.ObtenerFirmasPorMatriz(id_partida);

                if (firmas == null || !firmas.Any())
                {
                    return NotFound(new { mensaje = "No se encontraron firmas para esta matriz." });
                }

                return Ok(firmas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error en el servidor.", error = ex.Message });
            }
        }

    }
}
