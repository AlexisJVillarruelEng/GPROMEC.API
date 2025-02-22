using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IDetallePermisosGeneralRepository
    {
        Task<IEnumerable<DetallePermisosGeneral>> GetAllAsync();
        Task<DetallePermisosGeneral?> GetByIdAsync(int id);
        Task<DetallePermisosGeneral> AddAsync(DetallePermisosGeneral entity);
        Task UpdateAsync(DetallePermisosGeneral entity);
        Task DeleteAsync(int id);
    }
}
