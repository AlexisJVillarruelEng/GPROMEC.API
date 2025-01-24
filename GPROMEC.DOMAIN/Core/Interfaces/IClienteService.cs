using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IClientesService
    {
        Task<IEnumerable<ClienteDTO>> GetAllAsync(); // Obtener todos los clientes.
        Task<ClienteDTO> GetByIdAsync(int id); // Obtener un cliente por ID.
        Task<int> AddAsync(CrearClienteDTO clienteDto); // Insertar un cliente y devolver el ID.
        Task UpdateAsync(CrearClienteDTO clienteDto, int id); // Actualizar un cliente existente.
        Task DeleteAsync(int id); // Eliminar físicamente un cliente.
    }
}
