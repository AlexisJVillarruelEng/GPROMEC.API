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
    public class DetalleIpercService : IDetalleIpercService
    {
        private readonly IDetalleIpercRepository _repository;

        public DetalleIpercService(IDetalleIpercRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        public async Task<IEnumerable<DetalleIpercDTO>> GetAllAsync()
        {
            // Obtiene todos los registros del repositorio.
            var detalles = await _repository.GetAllAsync();
            return detalles.Select(MapToDTO); // Convierte a DTO.
        }

        public async Task<DetalleIpercDTO> GetByIdAsync(int id)
        {
            // Obtiene un registro por ID.
            var detalle = await _repository.GetByIdAsync(id);
            return detalle != null ? MapToDTO(detalle) : null; // Convierte a DTO o retorna null.
        }

        public async Task<int> AddAsync(CrearDetalleIpercDTO dto)
        {
            // Calcula los valores derivados.
            int probabilidad = dto.PersonasExpuestas + dto.ProcedimientosExistentes + dto.Capacitacion + dto.ExpoRiesgo;
            int nivelDeRiesgo = probabilidad * dto.Severidad;

            // Crea la entidad.
            var detalle = new DetalleIperc
            {
                IdTarea = dto.IdTarea,
                DescPeligros = dto.DescPeligros,
                TipoPeligro = dto.TipoPeligro,
                Riesgos = dto.Riesgos,
                TipoRiesgo = dto.TipoRiesgo,
                MedidaControlDescrip = dto.MedidaControlDescrip,
                PersonasExpuestas = dto.PersonasExpuestas,
                ProcedimietntosExistentes = dto.ProcedimientosExistentes,
                Capacitacion = dto.Capacitacion,
                ExpoRiesgo = dto.ExpoRiesgo,
                Probabilidad = probabilidad,
                Severidad = dto.Severidad,
                NivielDeRiesgo = nivelDeRiesgo,
                GradoRiesgo = EvaluarGradoDeRiesgo(nivelDeRiesgo)
            };

            // Llama al repositorio para guardar.
            return await _repository.AddAsync(detalle);
        }

        public async Task UpdateAsync(int id, CrearDetalleIpercDTO dto)
        {
            // Calcula los valores derivados.
            int probabilidad = dto.PersonasExpuestas + dto.ProcedimientosExistentes + dto.Capacitacion + dto.ExpoRiesgo;
            int nivelDeRiesgo = probabilidad * dto.Severidad;

            // Crea la entidad actualizada.
            var detalle = new DetalleIperc
            {
                IdDetalle = id,
                IdTarea = dto.IdTarea,
                DescPeligros = dto.DescPeligros,
                TipoPeligro = dto.TipoPeligro,
                Riesgos = dto.Riesgos,
                TipoRiesgo = dto.TipoRiesgo,
                MedidaControlDescrip = dto.MedidaControlDescrip,
                PersonasExpuestas = dto.PersonasExpuestas,
                ProcedimietntosExistentes = dto.ProcedimientosExistentes,
                Capacitacion = dto.Capacitacion,
                ExpoRiesgo = dto.ExpoRiesgo,
                Probabilidad = probabilidad,
                Severidad = dto.Severidad,
                NivielDeRiesgo = nivelDeRiesgo,
                GradoRiesgo = EvaluarGradoDeRiesgo(nivelDeRiesgo)
            };

            // Llama al repositorio para actualizar.
            await _repository.UpdateAsync(detalle);
        }

        public async Task DeleteAsync(int id)
        {
            // Llama al repositorio para eliminar.
            await _repository.DeleteAsync(id);
        }

        private string EvaluarGradoDeRiesgo(int nivelDeRiesgo)
        {
            // Determina el grado de riesgo basado en el nivel de riesgo.
            if (nivelDeRiesgo > 25 && nivelDeRiesgo <= 36) return "IT"; // Intolerable (25 < nivelDeRiesgo <= 36)
            if (nivelDeRiesgo >= 17 && nivelDeRiesgo <= 25) return "IM"; // Importante (17 <= nivelDeRiesgo <= 25)
            if (nivelDeRiesgo >= 9 && nivelDeRiesgo <= 16) return "MO"; // Moderado (9 <= nivelDeRiesgo <= 16)
            if (nivelDeRiesgo >= 5 && nivelDeRiesgo <= 8) return "TO"; // Tolerable (5 <= nivelDeRiesgo <= 8)
            if (nivelDeRiesgo >= 0 && nivelDeRiesgo <= 4) return "TR"; // Trivial (0 <= nivelDeRiesgo <= 4)

            return "Error en cálculo"; // Si no cae en ninguno de los rangos.
        }

        private DetalleIpercDTO MapToDTO(DetalleIperc detalle)
        {
            // Convierte la entidad a DTO.
            return new DetalleIpercDTO
            {
                IdDetalle = detalle.IdDetalle,
                IdTarea = detalle.IdTarea,
                DescPeligros = detalle.DescPeligros,
                TipoPeligro = detalle.TipoPeligro,
                Riesgos = detalle.Riesgos,
                TipoRiesgo = detalle.TipoRiesgo,
                MedidaControlDescrip = detalle.MedidaControlDescrip,
                PersonasExpuestas = detalle.PersonasExpuestas ?? 0,
                ProcedimientosExistentes = detalle.ProcedimietntosExistentes ?? 0,
                Capacitacion = detalle.Capacitacion ?? 0,
                ExpoRiesgo = detalle.ExpoRiesgo ?? 0,
                Probabilidad = detalle.Probabilidad ?? 0,
                Severidad = detalle.Severidad ?? 0,
                NivelDeRiesgo = detalle.NivielDeRiesgo ?? 0,
                GradoDeRiesgo = detalle.GradoRiesgo
            };
        }
    }
}
