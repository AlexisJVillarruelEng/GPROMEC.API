using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IUbigeoRepository
    {
        Task<IEnumerable<Ubigeo>> GetAllAsync();    // Obtener todos los Ubigeos
        Task<Ubigeo> GetByIdAsync(int id);          // Obtener un Ubigeo por ID
        Task<int> AddAsync(Ubigeo ubigeo);          // Crear un nuevo Ubigeo
        Task UpdateAsync(Ubigeo ubigeo);            // Actualizar un Ubigeo existente
        Task DeleteAsync(int id);                   // Eliminar un Ubigeo
    }
}
