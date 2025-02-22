using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IRespuestaPermisosRepository
    {
        Task<IEnumerable<RespuestaPermisos>> GetAllAsync();
        Task<RespuestaPermisos?> GetByIdAsync(int id);
        Task<RespuestaPermisos> AddAsync(RespuestaPermisos entity);
        Task UpdateAsync(int id, RespuestaPermisos entity);
        Task DeleteAsync(int id);
    }
}
