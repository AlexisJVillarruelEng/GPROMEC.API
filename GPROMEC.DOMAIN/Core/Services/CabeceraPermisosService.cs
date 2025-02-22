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
    public class CabeceraPermisosService : ICabeceraPermisosService
    {
        private readonly ICabeceraPermisosRepository _repository;

        public CabeceraPermisosService(ICabeceraPermisosRepository repository)
        {
            _repository = repository;
        }

        // Mapear Entidad -> DTO
        private CabeceraPermisosDTO MapToDTO(CabeceraPermisos entity)
        {
            return new CabeceraPermisosDTO
            {
                IdCabeceraPermisos = entity.IdCabeceraPermisos,
                IdCabeceraAts = entity.IdCabeceraAts,
                IdObra = entity.IdObra,
                Titulo = entity.Titulo,
                Fecha = (DateOnly)entity.Fecha, // Ahora es DateTime
                HoraInicio = entity.HoraInicio,
                HoraFin = entity.HoraFin,
                ObservacionConsideracion = entity.ObservacionConsideracion,
                IdPartida = entity.IdPartida,
                IdTarea = entity.IdTarea
            };
        }

        // Mapear DTO -> Entidad
        private CabeceraPermisos MapToEntity(CabeceraPermisosDTO dto)
        {
            return new CabeceraPermisos
            {
                IdCabeceraPermisos = dto.IdCabeceraPermisos,
                IdCabeceraAts = dto.IdCabeceraAts,
                IdObra = dto.IdObra,
                Titulo = dto.Titulo,
                Fecha = dto.Fecha, // DateTime
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                ObservacionConsideracion = dto.ObservacionConsideracion,
                IdPartida = dto.IdPartida,
                IdTarea = dto.IdTarea
            };
        }

        public async Task<IEnumerable<CabeceraPermisosDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDTO(e));
        }

        public async Task<CabeceraPermisosDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDTO(entity);
        }

        public async Task<CabeceraPermisosDTO> AddAsync(CabeceraPermisosDTO dto)
        {
            // Ignorar el ID del DTO en la creación
            dto.IdCabeceraPermisos = 0;
            var entity = MapToEntity(dto);
            var created = await _repository.AddAsync(entity);
            return MapToDTO(created);
        }

        public async Task UpdateAsync(int id, CabeceraPermisosDTO dto)
        {
            if (id != dto.IdCabeceraPermisos)
                throw new ArgumentException("El ID en la URL no coincide con el ID en el cuerpo del DTO.");

            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
