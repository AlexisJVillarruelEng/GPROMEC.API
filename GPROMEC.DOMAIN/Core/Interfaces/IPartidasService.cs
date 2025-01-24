using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IPartidasService
    {
        /// <summary>
        /// Obtiene todas las partidas.
        /// </summary>
        /// <returns>Una lista de partidas en formato DTO.</returns>
        Task<IEnumerable<PartidaDTO>> GetAllAsync();

        /// <summary>
        /// Obtiene una partida por su ID.
        /// </summary>
        /// <param name="id">ID de la partida a buscar.</param>
        /// <returns>La partida encontrada en formato DTO, o null si no existe.</returns>
        Task<PartidaDTO?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega una nueva partida.
        /// </summary>
        /// <param name="partidaDto">Datos de la partida a agregar.</param>
        /// <returns>El ID de la partida recién creada.</returns>
        Task<int> AddAsync(CrearPartidaDTO partidaDto);

        /// <summary>
        /// Actualiza una partida existente.
        /// </summary>
        /// <param name="partidaDto">Datos de la partida actualizados.</param>
        /// <param name="id">ID de la partida a actualizar.</param>
        Task UpdateAsync(CrearPartidaDTO partidaDto, int id);

        /// <summary>
        /// Elimina una partida de forma permanente.
        /// </summary>
        /// <param name="id">ID de la partida a eliminar.</param>
        Task DeleteAsync(int id);
    }
}
