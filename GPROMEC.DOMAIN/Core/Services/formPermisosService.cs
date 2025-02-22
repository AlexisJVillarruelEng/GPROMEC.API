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
    public class FormPermisoService : IFormPermisoService
    {
        private readonly IFormPermisoRepository _repository;

        public FormPermisoService(IFormPermisoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FormPermisosDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e));
        }

        public async Task<FormPermisosDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<FormPermisosDTO> AddAsync(FormPermisosDTO dto)
        {
            // Mapear sin asignar Id, ya que se genera automáticamente.
            var entity = MapToEntity(dto);
            var added = await _repository.AddAsync(entity);
            return MapToDto(added);
        }

        public async Task UpdateAsync(int id, FormPermisosDTO dto)
        {
            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Métodos de mapeo (puedes usar AutoMapper en producción)
        private static FormPermisosDTO MapToDto(FormPermisos entity) =>
            new FormPermisosDTO
            {
                IdForm = entity.IdForm,
                TituloPermiso = entity.TituloPermiso,
                DescripPreguntas = entity.DescripPreguntas
            };

        private static FormPermisos MapToEntity(FormPermisosDTO dto) =>
            new FormPermisos
            {
                // No asignar IdForm, se genera en la BD.
                TituloPermiso = dto.TituloPermiso,
                DescripPreguntas = dto.DescripPreguntas
            };
    }
}
