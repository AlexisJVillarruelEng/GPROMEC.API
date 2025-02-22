using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class FirmasAtsProcesosController : ControllerBase
    {
        private readonly IFirmasAtsProcesosService _service;
        public FirmasAtsProcesosController(IFirmasAtsProcesosService service)
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
        public async Task<IActionResult> Post([FromBody] FirmasAtsProcesosDto dto)
        {
            if (dto == null)
                return BadRequest();
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.IdFirmas }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FirmasAtsProcesosDto dto)
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
