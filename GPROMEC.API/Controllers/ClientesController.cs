using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPROMEC.API.Controllers
{
    [ApiController]
    [Route("gpromecAPIv1/[controller]")] // Ruta base: api/Clientes
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _service;

        public ClientesController(IClientesService service)
        {
            _service = service; // Inyección de dependencia del servicio.
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _service.GetAllAsync();
            return Ok(clientes); // Retorna 200 con la lista de clientes.
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            if (cliente == null) return NotFound(); // Retorna 404 si no se encuentra el cliente.
            return Ok(cliente); // Retorna 200 con los detalles del cliente.
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearClienteDTO clienteDto)
        {
            var id = await _service.AddAsync(clienteDto); // Crea el cliente y devuelve su ID.
            return CreatedAtAction(nameof(GetById), new { id }, new { Id = id, NombreCliente = clienteDto.NombreCliente });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearClienteDTO clienteDto)
        {
            await _service.UpdateAsync(clienteDto, id); // Actualiza el cliente.
            return NoContent(); // Retorna 204 si la operación fue exitosa.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id); // Elimina el cliente físicamente.
            return NoContent(); // Retorna 204 si la operación fue exitosa.
        }
    }
}
