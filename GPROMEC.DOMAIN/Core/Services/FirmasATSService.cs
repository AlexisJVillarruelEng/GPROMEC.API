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
    public class FirmasAtsProcesosService : IFirmasAtsProcesosService
    {
        private readonly IFirmasAtsProcesosRepository _repository;
        public FirmasAtsProcesosService(IFirmasAtsProcesosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FirmasAtsProcesosDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e));
        }

        public async Task<FirmasAtsProcesosDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<FirmasAtsProcesosDto> AddAsync(FirmasAtsProcesosDto dto)
        {
            var entity = MapToEntity(dto);
            var added = await _repository.AddAsync(entity);
            return MapToDto(added);
        }

        public async Task UpdateAsync(int id, FirmasAtsProcesosDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mappear de entidad a DTO
        private static FirmasAtsProcesosDto MapToDto(FirmasAtsProcesos entity) =>
            new FirmasAtsProcesosDto
            {
                IdFirmas = entity.IdFirmas,
                IdCabeceraPermisos = entity.IdCabeceraPermisos,
                IdCabeceraAts = entity.IdCabeceraAts,
                Elaborado = entity.Elaborado,
                Aprobado = entity.Aprobado,
                Revisado = entity.Revisado,
                FirmaElaboradoBase64 = entity.FirmaElaborado != null ? Convert.ToBase64String(entity.FirmaElaborado) : null,
                FirmaRevisadoBase64 = entity.FirmaRevisado != null ? Convert.ToBase64String(entity.FirmaRevisado) : null,
                FirmaAprobadoBase64 = entity.FirmaAprobado != null ? Convert.ToBase64String(entity.FirmaAprobado) : null
            };

        // Mappear de DTO a entidad (no asignar IdFirmas en POST)
        private static FirmasAtsProcesos MapToEntity(FirmasAtsProcesosDto dto) =>
            new FirmasAtsProcesos
            {
                // IdFirmas no se asigna si es null (POST)
                IdCabeceraPermisos = dto.IdCabeceraPermisos,
                IdCabeceraAts = dto.IdCabeceraAts,
                Elaborado = dto.Elaborado,
                Aprobado = dto.Aprobado,
                Revisado = dto.Revisado,
                FirmaElaborado = !string.IsNullOrEmpty(dto.FirmaElaboradoBase64) ? Convert.FromBase64String(dto.FirmaElaboradoBase64) : null,
                FirmaRevisado = !string.IsNullOrEmpty(dto.FirmaRevisadoBase64) ? Convert.FromBase64String(dto.FirmaRevisadoBase64) : null,
                FirmaAprobado = !string.IsNullOrEmpty(dto.FirmaAprobadoBase64) ? Convert.FromBase64String(dto.FirmaAprobadoBase64) : null
            };
    }
}
