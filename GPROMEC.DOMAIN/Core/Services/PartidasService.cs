using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Infrastructure.Repositories;

namespace GPROMEC.DOMAIN.Core.Services
{
    public class PartidasService : IPartidasService
    {
        private readonly IPartidasRepository _repository;

        public PartidasService(IPartidasRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        public async Task<IEnumerable<PartidaDTO>> GetAllAsync()
        {
            // Obtiene todas las partidas del repositorio.
            var partidas = await _repository.GetAllAsync();

            // Convierte las entidades a DTOs.
            return partidas.Select(p => new PartidaDTO
            {
                IdPartida = p.IdPartida,
                NombrePartida = p.NombrePartida,
                IdObra = p.IdObra,
                NombreObra = p.IdObraNavigation?.NombreObra
            });
        }

        public async Task<PartidaDTO?> GetByIdAsync(int id)
        {
            // Obtiene una partida por ID.
            var partida = await _repository.GetByIdAsync(id);
            if (partida == null) return null;

            // Convierte la entidad a DTO.
            return new PartidaDTO
            {
                IdPartida = partida.IdPartida,
                NombrePartida = partida.NombrePartida,
                IdObra = partida.IdObra,
                NombreObra = partida.IdObraNavigation?.NombreObra
            };
        }

        public async Task<int> AddAsync(CrearPartidaDTO partidaDto)
        {
            // Crea una nueva entidad a partir del DTO.
            var partida = new Partidas
            {
                NombrePartida = partidaDto.NombrePartida,
                IdObra = partidaDto.IdObra
            };

            // Llama al repositorio para agregar la partida.
            return await _repository.AddAsync(partida);
        }

        public async Task UpdateAsync(CrearPartidaDTO partidaDto, int id)
        {
            // Crea una entidad con los datos actualizados.
            var partida = new Partidas
            {
                IdPartida = id,
                NombrePartida = partidaDto.NombrePartida,
                IdObra = partidaDto.IdObra
            };

            // Llama al repositorio para actualizar.
            await _repository.UpdateAsync(partida);
        }

        public async Task DeleteAsync(int id)
        {
            // Llama al repositorio para eliminar permanentemente.
            await _repository.DeleteAsync(id);
        }
        public async Task<IEnumerable<Partidas>> ObtenerPartidasPorObra(int idObra)
        {
            return await _repository.ObtenerPartidasPorObra(idObra);
        }
    }
}
