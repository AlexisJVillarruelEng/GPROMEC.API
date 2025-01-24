using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RolesDTO>> GetAllAsync(); // Obtener todos los registros como DTO.
        Task<RolesDTO> GetByIdAsync(int id); // Obtener un registro por su ID como DTO.
        Task AddAsync(RolesDTO rolDto); // Insertar un nuevo registro desde un DTO.
        Task UpdateAsync(RolesDTO rolDto); // Actualizar un registro existente desde un DTO.
        Task DeleteAsync(int id); // Eliminar físicamente un registro.
    }
}
