using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IProcesosRepository
    {
        /// <summary>
        /// Obtiene todos los procesos, incluyendo la información de la partida relacionada.
        /// </summary>
        /// <returns>Una lista de entidades de procesos.</returns>
        Task<IEnumerable<Procesos>> GetAllAsync();

        /// <summary>
        /// Obtiene un proceso específico por su ID.
        /// </summary>
        /// <param name="id">ID del proceso.</param>
        /// <returns>La entidad del proceso encontrada, o null si no existe.</returns>
        Task<Procesos?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega un nuevo proceso.
        /// </summary>
        /// <param name="proceso">Entidad del proceso a agregar.</param>
        /// <returns>El ID del proceso recién creado.</returns>
        Task<int> AddAsync(Procesos proceso);

        /// <summary>
        /// Actualiza un proceso existente.
        /// </summary>
        /// <param name="proceso">Entidad del proceso actualizada.</param>
        Task UpdateAsync(Procesos proceso);

        /// <summary>
        /// Elimina un proceso de forma permanente.
        /// </summary>
        /// <param name="id">ID del proceso a eliminar.</param>
        Task DeleteAsync(int id);
    }
}
