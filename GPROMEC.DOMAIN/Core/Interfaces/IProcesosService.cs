using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IProcesosService
    {
        /// <summary>
        /// Obtiene todos los procesos.
        /// </summary>
        /// <returns>Una lista de DTOs de procesos.</returns>
        Task<IEnumerable<ProcesoDTO>> GetAllAsync();

        /// <summary>
        /// Obtiene un proceso específico por su ID.
        /// </summary>
        /// <param name="id">ID del proceso.</param>
        /// <returns>El DTO del proceso encontrado, o null si no existe.</returns>
        Task<ProcesoDTO?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega un nuevo proceso.
        /// </summary>
        /// <param name="dto">DTO del proceso a agregar.</param>
        /// <returns>El ID del proceso recién creado.</returns>
        Task<int> AddAsync(CrearProcesoDTO dto);

        /// <summary>
        /// Actualiza un proceso existente.
        /// </summary>
        /// <param name="dto">DTO del proceso actualizado.</param>
        /// <param name="id">ID del proceso a actualizar.</param>
        Task UpdateAsync(CrearProcesoDTO dto, int id);

        /// <summary>
        /// Elimina un proceso de forma permanente.
        /// </summary>
        /// <param name="id">ID del proceso a eliminar.</param>
        Task DeleteAsync(int id);
    }
}
