using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly IPartidasService _service;

        public PartidasController(IPartidasService service)
        {
            _service = service; // Inyección del servicio.
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Obtiene todas las partidas.
            var partidas = await _service.GetAllAsync();
            return Ok(partidas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Obtiene una partida por ID.
            var partida = await _service.GetByIdAsync(id);
            if (partida == null) return NotFound();
            return Ok(partida);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CrearPartidaDTO partidaDto)
        {
            // Agrega una nueva partida.
            var id = await _service.AddAsync(partidaDto);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearPartidaDTO partidaDto)
        {
            // Actualiza una partida existente.
            await _service.UpdateAsync(partidaDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Elimina una partida de forma permanente.
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
