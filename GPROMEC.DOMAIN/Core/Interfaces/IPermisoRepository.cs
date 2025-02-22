using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IPermisoRepository
    {
        Task<IEnumerable<Permisos>> GetAllAsync();
        Task<Permisos?> GetByIdAsync(int id);
        Task<Permisos> AddAsync(Permisos entity);
        Task UpdateAsync(int id, Permisos entity);
        Task DeleteAsync(int id);
    }
}
