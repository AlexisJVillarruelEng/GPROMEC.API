using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ICabeceraPermisosService
    {
        Task<IEnumerable<CabeceraPermisosDTO>> GetAllAsync();
        Task<CabeceraPermisosDTO?> GetByIdAsync(int id);
        Task<CabeceraPermisosDTO> AddAsync(CabeceraPermisosDTO dto);
        Task UpdateAsync(int id, CabeceraPermisosDTO dto);
        Task DeleteAsync(int id);
    }
}
