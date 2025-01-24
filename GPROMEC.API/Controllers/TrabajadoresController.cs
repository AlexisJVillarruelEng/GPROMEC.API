using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [ApiController]
    [Route("gpromecAPIv1/[controller]")] // Ruta base: api/Trabajadores
    public class TrabajadoresController : ControllerBase
    {
        private readonly ITrabajadoresService _service;

        // Inyección de dependencia del servicio.
        public TrabajadoresController(ITrabajadoresService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtener todos los trabajadores (activos e inactivos según el parámetro).
        /// </summary>
        /// <param name="incluirInactivos">Determina si se incluyen los inactivos.</param>
        /// <returns>Lista de trabajadores.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool incluirInactivos = false)
        {
            var trabajadores = await _service.GetAllAsync(incluirInactivos);
            return Ok(trabajadores); // Retorna un código 200 con la lista de trabajadores.
        }

        /// <summary>
        /// Obtener un trabajador por su ID.
        /// </summary>
        /// <param name="id">ID del trabajador.</param>
        /// <returns>Detalles del trabajador.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trabajador = await _service.GetByIdAsync(id);
            if (trabajador == null) return NotFound(); // Retorna 404 si no se encuentra el trabajador.
            return Ok(trabajador); // Retorna 200 con los detalles del trabajador.
        }

        /// <summary>
        /// Crear un nuevo trabajador.
        /// </summary>
        /// <param name="trabajadorDto">Datos del nuevo trabajador.</param>
        /// <returns>ID y nombre del trabajador creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearTrabajadorDTO trabajadorDto)
        {
            var id = await _service.AddAsync(trabajadorDto); // Crea el trabajador y obtiene su ID.
            var trabajador = await _service.GetByIdAsync(id); // Obtiene los datos completos para devolver el nombre.

            return CreatedAtAction(nameof(GetById), new { id }, new
            {
                Id = id,
                Nombre = trabajador.Nombre
            });
        }

        /// <summary>
        /// Validar el inicio de sesión de un trabajador.
        /// </summary>
        /// <param name="inicioSesionDto">Credenciales de inicio de sesión.</param>
        /// <returns>Nombre del trabajador si las credenciales son válidas.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] InicioSesionDTO inicioSesionDto)
        {
            var nombre = await _service.IniciarSesionAsync(inicioSesionDto);
            if (nombre == null) return Unauthorized(); // Retorna 401 si las credenciales no son válidas.
            return Ok(new { Nombre = nombre }); // Retorna 200 con el nombre del trabajador.
        }

        /// <summary>
        /// Actualizar un trabajador existente.
        /// </summary>
        /// <param name="id">ID del trabajador a actualizar.</param>
        /// <param name="trabajadorDto">Datos actualizados del trabajador.</param>
        /// <returns>No Content (204) si la operación fue exitosa.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearTrabajadorDTO trabajadorDto)
        {
            await _service.UpdateAsync(trabajadorDto, id);
            return NoContent(); // Retorna 204 si la operación fue exitosa.
        }

        /// <summary>
        /// Eliminar lógicamente un trabajador.
        /// </summary>
        /// <param name="id">ID del trabajador a eliminar lógicamente.</param>
        /// <returns>No Content (204) si la operación fue exitosa.</returns>
        [HttpDelete("logical/{id}")]
        public async Task<IActionResult> DeleteLogically(int id)
        {
            await _service.DeleteLogicallyAsync(id);
            return NoContent(); // Retorna 204 si la operación fue exitosa.
        }

        /// <summary>
        /// Eliminar físicamente un trabajador.
        /// </summary>
        /// <param name="id">ID del trabajador a eliminar físicamente.</param>
        /// <returns>No Content (204) si la operación fue exitosa.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermanently(int id)
        {
            await _service.DeletePermanentlyAsync(id);
            return NoContent(); // Retorna 204 si la operación fue exitosa.
        }
    }
}
