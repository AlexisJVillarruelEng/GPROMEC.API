using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;

namespace GPROMEC.DOMAIN.Core.Interfaces
{
    public interface IPartidasRepository
    {
        /// <summary>
        /// Obtiene todas las partidas, incluyendo la información de la obra relacionada.
        /// </summary>
        /// <returns>Una lista de entidades de partidas.</returns>
        Task<IEnumerable<Partidas>> GetAllAsync();

        /// <summary>
        /// Obtiene una partida específica por su ID.
        /// </summary>
        /// <param name="id">ID de la partida.</param>
        /// <returns>La entidad de la partida encontrada, o null si no existe.</returns>
        Task<Partidas?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega una nueva partida.
        /// </summary>
        /// <param name="partida">Entidad de la partida a agregar.</param>
        /// <returns>El ID de la partida recién creada.</returns>
        Task<int> AddAsync(Partidas partida);

        /// <summary>
        /// Actualiza una partida existente.
        /// </summary>
        /// <param name="partida">Entidad de la partida actualizada.</param>
        Task UpdateAsync(Partidas partida);

        /// <summary>
        /// Elimina una partida de forma permanente.
        /// </summary>
        /// <param name="id">ID de la partida a eliminar.</param>
        Task DeleteAsync(int id);
        Task<IEnumerable<Partidas>> ObtenerPartidasPorObra(int idObra);
    }
}
