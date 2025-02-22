using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;

namespace GPROMEC.DOMAIN.Core.Services
{
    public class CabeceraATSService : ICabeceraATSService
    {
        private readonly ICabeceraATSRepository _repository;
        public CabeceraATSService(ICabeceraATSRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CabeceraATSDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e));
        }

        public async Task<CabeceraATSDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : MapToDto(entity);
        }

        public async Task<CabeceraATSDto> AddAsync(CabeceraATSDto dto)
        {
            // No enviar Id en el POST (ya es Identity)
            var entity = MapToEntity(dto);
            var added = await _repository.AddAsync(entity);
            return MapToDto(added);
        }

        public async Task UpdateAsync(int id, CabeceraATSDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeos (pueden hacerse con AutoMapper en producción)
        private static CabeceraATSDto MapToDto(CabeceraAts entity) =>
            new CabeceraATSDto
            {
                IdCabeceraATS = entity.IdCabeceraats,
                IdObra = entity.IdObra,
                IdPartida = entity.IdPartida,
                IdTarea = entity.IdTarea,
                EsRutinaria = (bool)entity.EsRutinaria,
                Sector = entity.Sector,
                Fecha = entity.Fecha,
                Hora = entity.Hora,
                RiesgoIdentify = (bool)entity.RiesgoIdentify,
                EvaluoCondiciones = (bool)entity.EvaluoCondiciones,
                EpAdecuados = (bool)entity.EpAdecuados,
                PersonalCapacitado = (bool)entity.PersonalCapacitado,
                CordinacionActividades = (bool)entity.CordinacionActividades,
                CondicionEquipo = (bool)entity.CondicionEquipo,
                RiesgoIncendio = (bool)entity.RiesgoIncendio,
                TrabajoAltura = (bool)entity.TrabajoAltura,
                Andamios = (bool)entity.Andamios,
                TrabajoCaliente = (bool)entity.TrabajoCaliente,
                ComprometeCondicion = (bool)entity.ComprometeCondicion,
                IdPermiso = entity.IdPermiso,
                Pilar1 = (bool)entity.Pilar1,
                Pilar2 = (bool)entity.Pilar2,
                Pilar3 = (bool)entity.Pilar3,
                Pilar4 = (bool)entity.Pilar4,
                Pilar5 = (bool)entity.Pilar5
            };

        private static CabeceraAts MapToEntity(CabeceraATSDto dto) =>
            new CabeceraAts
            {
                // En el POST no se espera valor en IdCabeceraATS
                IdObra = dto.IdObra,
                IdPartida = dto.IdPartida,
                IdTarea = dto.IdTarea,
                EsRutinaria = dto.EsRutinaria,
                Sector = dto.Sector,
                Fecha = dto.Fecha,
                Hora = dto.Hora,
                RiesgoIdentify = dto.RiesgoIdentify,
                EvaluoCondiciones = dto.EvaluoCondiciones,
                EpAdecuados = dto.EpAdecuados,
                PersonalCapacitado = dto.PersonalCapacitado,
                CordinacionActividades = dto.CordinacionActividades,
                CondicionEquipo = dto.CondicionEquipo,
                RiesgoIncendio = dto.RiesgoIncendio,
                TrabajoAltura = dto.TrabajoAltura,
                Andamios = dto.Andamios,
                TrabajoCaliente = dto.TrabajoCaliente,
                ComprometeCondicion = dto.ComprometeCondicion,
                IdPermiso = dto.IdPermiso,
                Pilar1 = dto.Pilar1,
                Pilar2 = dto.Pilar2,
                Pilar3 = dto.Pilar3,
                Pilar4 = dto.Pilar4,
                Pilar5 = dto.Pilar5
            };
    }
}
