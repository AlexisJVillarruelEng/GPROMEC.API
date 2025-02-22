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
        Task<IEnumerable<DetalleATSDto>> GetAllAsync();
        Task<DetalleATSDto?> GetByIdAsync(int id);
        Task<DetalleATSDto> AddAsync(DetalleATSDto dto);
        Task UpdateAsync(int id, DetalleATSDto dto);
        Task DeleteAsync(int id);
    }
}
