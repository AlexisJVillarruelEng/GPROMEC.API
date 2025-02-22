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

    public class RespuestaPermisosService : IRespuestaPermisosService
    {
        private readonly IRespuestaPermisosRepository _repository;
        public RespuestaPermisosService(IRespuestaPermisosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RespuestaPermisosDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e));
        }

        public async Task<RespuestaPermisosDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<RespuestaPermisosDTO> AddAsync(RespuestaPermisosDTO dto)
        {
            // No se debe enviar el Id en POST; la BD lo genera
            var entity = new RespuestaPermisos
            {
                IdForm = dto.IdForm,
                IdCabeceraPermisos = dto.IdCabeceraPermisos,
                Respuesta = dto.Respuesta
            };

            var added = await _repository.AddAsync(entity);
            return MapToDto(added);
        }

        public async Task UpdateAsync(int id, RespuestaPermisosDTO dto)
        {
            var entity = new RespuestaPermisos
            {
                // No se actualiza el Id; se actualizan los demás campos
                IdForm = dto.IdForm,
                IdCabeceraPermisos = dto.IdCabeceraPermisos,
                Respuesta = dto.Respuesta
            };

            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private static RespuestaPermisosDTO MapToDto(RespuestaPermisos entity) =>
            new RespuestaPermisosDTO
            {
                IdRespuesta = entity.IdRespuesta,
                IdForm = entity.IdForm,
                IdCabeceraPermisos = entity.IdCabeceraPermisos,
                Respuesta = entity.Respuesta
            };
    }
}
