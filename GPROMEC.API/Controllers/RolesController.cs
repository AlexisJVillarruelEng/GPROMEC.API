using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _service; // Servicio de Roles.

        public RolesController(IRolesService service)
        {
            _service = service; // Inyección del servicio.
        }

        // Endpoint para obtener todos los roles.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllAsync(); // Llama al servicio.
            return Ok(roles); // Retorna los datos con estado 200.
        }

        // Endpoint para obtener un rol por su ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _service.GetByIdAsync(id); // Busca el rol por ID.
            if (rol == null) return NotFound(); // Retorna 404 si no se encuentra.
            return Ok(rol); // Retorna el rol encontrado.
        }

        // Endpoint para crear un nuevo rol.
        [HttpPost]
        public async Task<IActionResult> Create(RolesDTO rolDto)
        {
            await _service.AddAsync(rolDto); // Llama al servicio para crear.
            return CreatedAtAction(nameof(GetById), new { id = rolDto.IdRol }, rolDto); // Retorna 201.
        }

        // Endpoint para actualizar un rol.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RolesDTO rolDto)
        {
            if (id != rolDto.IdRol) return BadRequest(); // Valida si el ID coincide.
            await _service.UpdateAsync(rolDto); // Actualiza el rol.
            return NoContent(); // Retorna 204 si se actualizó correctamente.
        }

        // Endpoint para eliminar un rol.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id); // Llama al servicio para eliminar.
            return NoContent(); // Retorna 204 si se eliminó correctamente.
        }
    }
}
