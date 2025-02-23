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
    public class DetalleAtsService : IDetalleATSService
    {
        private readonly IDetalleATSRepository _repo;

        public DetalleAtsService(IDetalleATSRepository repo)
        {
            _repo = repo;
        }

        public async Task<DetalleAtsDto> AddAsync(DetalleAtsCreateUpdateDto dto)
        {
            var entity = new DetalleAts
            {
                // No se asigna IdDetalleAts, se genera automáticamente.
                IdCabeceraats = dto.IdCabeceraAts,
                EtapasTrabajo = dto.EtapasTrabajo,
                IdDetalleiperc = dto.IdDetalleIperc,
                Personal = dto.Personal,
                FirmaPersonal = dto.FirmaPersonalBase64 != null
                                ? Convert.FromBase64String(dto.FirmaPersonalBase64)
                                : null
            };

            var created = await _repo.AddAsync(entity);
            return MapToDto(created);
        }

        public async Task<IEnumerable<DetalleAtsDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(x => MapToDto(x));
        }

        public async Task<DetalleAtsDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task UpdateAsync(int id, DetalleAtsCreateUpdateDto dto)
        {
            var entity = new DetalleAts
            {
                IdDetalleAts = id,
                IdCabeceraats = dto.IdCabeceraAts,
                EtapasTrabajo = dto.EtapasTrabajo,
                IdDetalleiperc = dto.IdDetalleIperc,
                Personal = dto.Personal,
                FirmaPersonal = dto.FirmaPersonalBase64 != null
                                ? Convert.FromBase64String(dto.FirmaPersonalBase64)
                                : null
            };

            await _repo.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        private DetalleAtsDto MapToDto(DetalleAts entity)
        {
            return new DetalleAtsDto
            {
                IdDetalleAts = entity.IdDetalleAts,
                IdCabeceraAts = entity.IdCabeceraats,
                EtapasTrabajo = entity.EtapasTrabajo,
                IdDetalleIperc = entity.IdDetalleiperc,
                Personal = entity.Personal,
                FirmaPersonalBase64 = entity.FirmaPersonal != null ? Convert.ToBase64String(entity.FirmaPersonal) : null,
                DetallePeligros = entity.IdDetalleipercNavigation != null
                    ? new DetalleIpercDTO
                    {
                        IdDetalle = entity.IdDetalleipercNavigation.IdDetalle,
                        IdTarea = entity.IdDetalleipercNavigation.IdTarea,
                        DescPeligros = entity.IdDetalleipercNavigation.DescPeligros,
                        TipoPeligro = entity.IdDetalleipercNavigation.TipoPeligro,
                        Riesgos = entity.IdDetalleipercNavigation.Riesgos,
                        TipoRiesgo = entity.IdDetalleipercNavigation.TipoRiesgo,
                        MedidaControlDescrip = entity.IdDetalleipercNavigation.MedidaControlDescrip,
                        PersonasExpuestas = entity.IdDetalleipercNavigation.PersonasExpuestas ?? 0,
                        ProcedimientosExistentes = entity.IdDetalleipercNavigation.ProcedimietntosExistentes ?? 0,
                        Capacitacion = entity.IdDetalleipercNavigation.Capacitacion ?? 0,
                        ExpoRiesgo = entity.IdDetalleipercNavigation.ExpoRiesgo ?? 0,
                        Probabilidad = entity.IdDetalleipercNavigation.Probabilidad ?? 0,
                        Severidad = entity.IdDetalleipercNavigation.Severidad ?? 0,
                        NivelDeRiesgo = entity.IdDetalleipercNavigation.NivielDeRiesgo ?? 0,
                        GradoDeRiesgo = entity.IdDetalleipercNavigation.GradoRiesgo
                    }
                    : null
            };
        }
    }
}
