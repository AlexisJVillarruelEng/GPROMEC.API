using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ICabeceraATSService
    {
        Task<IEnumerable<CabeceraATSDto>> GetAllAsync();
        Task<CabeceraATSDto?> GetByIdAsync(int id);
        Task<CabeceraATSDto> AddAsync(CabeceraATSDto dto);
        Task UpdateAsync(int id, CabeceraATSDto dto);
        Task DeleteAsync(int id);
    }
}
