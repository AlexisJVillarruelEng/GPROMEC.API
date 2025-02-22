using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IDetalleATSRepository
    {
        Task<IEnumerable<DetalleAts>> GetAllAsync();
        Task<DetalleAts?> GetByIdAsync(int id);
        Task<DetalleAts> AddAsync(DetalleAts entity);
        Task UpdateAsync(int id, DetalleAts entity);
        Task DeleteAsync(int id);
    }
}
