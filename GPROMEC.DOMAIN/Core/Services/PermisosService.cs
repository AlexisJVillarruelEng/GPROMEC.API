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
    public class PermisoService : IPermisoService
    {
        private readonly IPermisoRepository _repository;
        public PermisoService(IPermisoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PermisoDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e));
        }

        public async Task<PermisoDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<PermisoDto> AddAsync(PermisoDto dto)
        {
            var entity = MapToEntity(dto);
            var added = await _repository.AddAsync(entity);
            return MapToDto(added);
        }

        public async Task UpdateAsync(int id, PermisoDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeos (pueden ser reemplazados por AutoMapper en producción)
        private static PermisoDto MapToDto(Permisos entity) =>
            new PermisoDto
            {
                IdPermiso = entity.IdPermiso,
                TituloPermiso = entity.TituloPermiso
            };

        private static Permisos MapToEntity(PermisoDto dto) =>
            new Permisos
            {
                // No asignar Id en POST, ya que es Identity.
                TituloPermiso = dto.TituloPermiso
            };
    }
}
