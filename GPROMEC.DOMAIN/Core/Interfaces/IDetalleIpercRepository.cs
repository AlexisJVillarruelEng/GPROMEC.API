using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IDetalleIpercRepository
    {
        Task<IEnumerable<DetalleIperc>> GetAllAsync(); // Obtener todos los registros.
        Task<DetalleIperc> GetByIdAsync(int id); // Obtener un registro por ID.
        Task<int> AddAsync(DetalleIperc detalle); // Crear un nuevo registro.
        Task UpdateAsync(DetalleIperc detalle); // Actualizar un registro.
        Task DeleteAsync(int id); // Eliminar un registro.
        Task<IEnumerable<DetalleIperc>> ObtenerDetallesPorTarea(int idTarea);
    }
}
