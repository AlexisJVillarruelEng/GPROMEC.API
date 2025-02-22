using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IDetallePermisosGeneralService
    {
        Task<IEnumerable<DetallePermisoGeneral>> GetAllAsync();
        Task<DetallePermisoGeneral?> GetByIdAsync(int id);
        Task<DetallePermisoGeneral> AddAsync(DetallePermisoGeneral dto);
        Task UpdateAsync(int id, DetallePermisoGeneral dto);
        Task DeleteAsync(int id);
    }
}
