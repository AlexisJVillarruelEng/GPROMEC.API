using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IRolesRepository
    
    {
        Task<IEnumerable<Roles>> GetAllAsync(); // Obtener todos los registros.
        Task<Roles> GetByIdAsync(int id); // Obtener un registro por ID.
        Task AddAsync(Roles rol); // Insertar un nuevo registro.
        Task UpdateAsync(Roles rol); // Actualizar un registro existente.
        Task DeleteAsync(int id); // Eliminar físicamente un registro.
    }

}
