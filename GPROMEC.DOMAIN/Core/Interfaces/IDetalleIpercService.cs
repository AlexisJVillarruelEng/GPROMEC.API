using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IDetalleIpercService
    {
        Task<IEnumerable<DetalleIpercDTO>> GetAllAsync(); // Obtener todos los registros.
        Task<DetalleIpercDTO> GetByIdAsync(int id); // Obtener un registro por ID.
        Task<int> AddAsync(CrearDetalleIpercDTO dto); // Crear un nuevo registro.
        Task UpdateAsync(int id, CrearDetalleIpercDTO dto); // Actualizar un registro.
        Task DeleteAsync(int id); // Eliminar un registro (físico).
        Task<IEnumerable<DetalleIperc>> ObtenerDetallesPorTarea(int idTarea);
    }
}
