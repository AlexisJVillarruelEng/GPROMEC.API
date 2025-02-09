using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface ITareasService
    {
        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        Task<IEnumerable<TareaDTO>> GetAllAsync();

        /// <summary>
        /// Obtiene una tarea por su ID.
        /// </summary>
        Task<TareaDTO?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega una nueva tarea.
        /// </summary>
        Task<int> AddAsync(CrearTareaDTO tareaDto);

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        Task UpdateAsync(CrearTareaDTO tareaDto, int id);

        /// <summary>
        /// Elimina una tarea de forma permanente.
        /// </summary>
        Task DeleteAsync(int id);
        Task<IEnumerable<Tareas>> ObtenerTareasPorProceso(int idProceso);
    }
}
