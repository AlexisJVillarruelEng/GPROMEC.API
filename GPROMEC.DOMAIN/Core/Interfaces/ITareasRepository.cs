using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ITareasRepository
    {
        /// <summary>
        /// Obtiene todas las tareas con sus procesos relacionados.
        /// </summary>
        Task<IEnumerable<Tareas>> GetAllAsync();

        /// <summary>
        /// Obtiene una tarea específica por su ID.
        /// </summary>
        Task<Tareas?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega una nueva tarea.
        /// </summary>
        Task<int> AddAsync(Tareas tarea);

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        Task UpdateAsync(Tareas tarea);

        /// <summary>
        /// Elimina una tarea de forma permanente.
        /// </summary>
        Task DeleteAsync(int id);
        Task<IEnumerable<Tareas>> ObtenerTareasPorProceso(int idProceso);
    }
}
