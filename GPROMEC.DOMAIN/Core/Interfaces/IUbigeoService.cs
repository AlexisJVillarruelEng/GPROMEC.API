using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IUbigeoService
    {
        Task<IEnumerable<UbigeoDTO>> GetAllAsync(); // Obtener todos los Ubigeos
        Task<UbigeoDTO> GetByIdAsync(int id);       // Obtener un Ubigeo por ID
        Task<int> AddAsync(CrearUbigeoDTO ubigeo);  // Crear un nuevo Ubigeo
        Task UpdateAsync(int id, CrearUbigeoDTO ubigeo); // Actualizar un Ubigeo existente
        Task DeleteAsync(int id);                  // Eliminar un Ubigeo
    }
}
