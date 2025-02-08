using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IObrasRepository
    {
        Task<IEnumerable<Obras>> GetAllAsync(); // Obtiene todas las obras.
        Task<Obras?> GetByIdAsync(int id); // Obtiene una obra por su ID.
        Task<int> AddAsync(Obras obra); // Crea una nueva obra.
        Task UpdateAsync(Obras obra); // Actualiza una obra existente.
        Task DeleteAsync(int id); // Elimina una obra permanentemente.

        Task<IEnumerable<Obras>> ObtenerObrasPorProyectoAsync(int idProyecto);
    }
}
