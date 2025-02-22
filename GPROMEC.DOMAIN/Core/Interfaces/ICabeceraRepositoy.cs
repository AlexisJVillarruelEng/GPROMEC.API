using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ICabeceraPermisosRepository
    {
        Task<IEnumerable<CabeceraPermisos>> GetAllAsync();
        Task<CabeceraPermisos?> GetByIdAsync(int id);
        Task<CabeceraPermisos> AddAsync(CabeceraPermisos entity);
        Task UpdateAsync(CabeceraPermisos entity);
        Task DeleteAsync(int id);
    }
}
