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
    public class DetallePermisoGeneralService : IDetallePermisosGeneralService
    {
        private readonly IDetallePermisosGeneralRepository _repository;
        public DetallePermisoGeneralService(IDetallePermisosGeneralRepository repository)
        {
            _repository = repository;
        }

        // Método para convertir entidad a DTO
        private DetallePermisoGeneral MapToDTO(DetallePermisosGeneral entity)
        {
            return new DetallePermisoGeneral
            {
                IdDetalle = entity.IdDetallePermiso,
                IdCabeceraPermisos = entity.IdCabeceraPermisos,
                Trabajador = entity.Trabajador,
                FirmaTrabajadorBase64 = entity.FirmaTrabajador != null
                                            ? Convert.ToBase64String(entity.FirmaTrabajador)
                                            : null
            };
        }

        // Método para convertir DTO a entidad
        private DetallePermisosGeneral MapToEntity(DetallePermisoGeneral dto)
        {
            return new DetallePermisosGeneral
            {
                IdDetallePermiso = dto.IdDetalle,
                IdCabeceraPermisos = dto.IdCabeceraPermisos,
                Trabajador = dto.Trabajador,
                FirmaTrabajador = !string.IsNullOrEmpty(dto.FirmaTrabajadorBase64)
                                    ? Convert.FromBase64String(dto.FirmaTrabajadorBase64)
                                    : null
            };
        }

        public async Task<IEnumerable<DetallePermisoGeneral>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDTO(e));
        }

        public async Task<DetallePermisoGeneral?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDTO(entity);
        }

        public async Task<DetallePermisoGeneral> AddAsync(DetallePermisoGeneral dto)
        {
            var entity = MapToEntity(dto);
            var createdEntity = await _repository.AddAsync(entity);
            return MapToDTO(createdEntity);
        }

        public async Task UpdateAsync(int id, DetallePermisoGeneral dto)
        {
            if (id != dto.IdDetalle)
                throw new ArgumentException("El ID proporcionado no coincide con el ID del DTO.");
            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
