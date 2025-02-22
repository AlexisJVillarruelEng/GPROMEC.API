using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IPermisoService
    {
        Task<IEnumerable<PermisoDto>> GetAllAsync();
        Task<PermisoDto?> GetByIdAsync(int id);
        Task<PermisoDto> AddAsync(PermisoDto dto);
        Task UpdateAsync(int id, PermisoDto dto);
        Task DeleteAsync(int id);
    }
}
