using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoService _service;

        public UbigeoController(IUbigeoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ubigeos = await _service.GetAllAsync();
            return Ok(ubigeos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ubigeo = await _service.GetByIdAsync(id);
            if (ubigeo == null) return NotFound();
            return Ok(ubigeo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearUbigeoDTO ubigeoDto)
        {
            var id = await _service.AddAsync(ubigeoDto);
            return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearUbigeoDTO ubigeoDto)
        {
            await _service.UpdateAsync(id, ubigeoDto);
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
