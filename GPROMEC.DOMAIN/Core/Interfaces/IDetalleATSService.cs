using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IDetalleATSService
    {
        Task<IEnumerable<DetalleAtsDto>> GetAllAsync();
        Task<DetalleAtsDto?> GetByIdAsync(int id);
        Task<DetalleAtsDto> AddAsync(DetalleAtsCreateUpdateDto dto);
        Task UpdateAsync(int id, DetalleAtsCreateUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
