using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IRespuestaPermisosService
    {
        Task<IEnumerable<RespuestaPermisosDTO>> GetAllAsync();
        Task<RespuestaPermisosDTO?> GetByIdAsync(int id);
        Task<RespuestaPermisosDTO> AddAsync(RespuestaPermisosDTO dto);
        Task UpdateAsync(int id, RespuestaPermisosDTO dto);
        Task DeleteAsync(int id);
    }
}
