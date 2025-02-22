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
    public class DetalleATSService : IDetalleATSService
    {
        private readonly IDetalleATSRepository _repository;
        public DetalleATSService(IDetalleATSRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DetalleATSDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e));
        }

        public async Task<DetalleATSDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<DetalleATSDto> AddAsync(DetalleATSDto dto)
        {
            var entity = MapToEntity(dto);
            var added = await _repository.AddAsync(entity);
            return MapToDto(added);
        }

        public async Task UpdateAsync(int id, DetalleATSDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeos manuales (puedes usar AutoMapper en producción)
        private static DetalleATSDto MapToDto(DetalleAts entity) =>
            new DetalleATSDto
            {
                IdDetalleATS = entity.IdDetalleAts,
                IdCabeceraATS = entity.IdCabeceraats,
                EtapasTrabajo = entity.EtapasTrabajo,
                Peligros = entity.Peligros,
                RiesgoAmbiental = entity.RiesgoAmbiental,
                MedidaRiesgo = entity.MedidaRiesgo,
                Personal = entity.Personal,
                // Convertir byte[] a base64 (si existe)
                FirmaPersonalBase64 = entity.FirmaPersonal != null ? Convert.ToBase64String(entity.FirmaPersonal) : null
            };

        private static DetalleAts MapToEntity(DetalleATSDto dto) =>
            new DetalleAts
            {
                // No asignar Id en POST, ya que es Identity.
                IdCabeceraats = dto.IdCabeceraATS,
                EtapasTrabajo = dto.EtapasTrabajo,
                Peligros = dto.Peligros,
                RiesgoAmbiental = dto.RiesgoAmbiental,
                MedidaRiesgo = dto.MedidaRiesgo,
                Personal = dto.Personal,
                // Convertir base64 a byte[] si se proporcionó
                FirmaPersonal = !string.IsNullOrEmpty(dto.FirmaPersonalBase64) ? Convert.FromBase64String(dto.FirmaPersonalBase64) : null
            };
    }
}
