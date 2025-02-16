using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync(); // Obtener todos los clientes.
        Task<Clientes> GetByIdAsync(int id); // Obtener un cliente por ID.
        Task<int> AddAsync(Clientes cliente); // Insertar un nuevo cliente.
        Task UpdateAsync(Clientes cliente); // Actualizar un cliente existente.
        Task DeleteAsync(int id); // Eliminar físicamente un cliente.

        Task<Clientes> LoginAsync(string nombre, string correo, string telefono);
    }
}
