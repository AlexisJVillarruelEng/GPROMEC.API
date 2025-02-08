using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IObrasService
    {
        /// <summary>
        /// Obtiene todas las obras.
        /// </summary>
        /// <returns>Una lista de obras en formato DTO.</returns>
        Task<IEnumerable<ObraDTO>> GetAllAsync();

        /// <summary>
        /// Obtiene una obra por su ID.
        /// </summary>
        /// <param name="id">ID de la obra a buscar.</param>
        /// <returns>La obra encontrada en formato DTO, o null si no existe.</returns>
        Task<ObraDTO?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega una nueva obra.
        /// </summary>
        /// <param name="obraDto">Datos de la obra a agregar.</param>
        /// <returns>El ID de la obra recién creada.</returns>
        Task<int> AddAsync(CrearObraDTO obraDto);

        /// <summary>
        /// Actualiza una obra existente.
        /// </summary>
        /// <param name="obraDto">Datos de la obra actualizados.</param>
        /// <param name="id">ID de la obra a actualizar.</param>
        Task UpdateAsync(CrearObraDTO obraDto, int id);

        /// <summary>
        /// Elimina una obra de forma permanente.
        /// </summary>
        /// <param name="id">ID de la obra a eliminar.</param>
        Task DeleteAsync(int id);
        Task<IEnumerable<Obras>> ObtenerObrasPorProyectoAsync(int idProyecto);
    }
}
