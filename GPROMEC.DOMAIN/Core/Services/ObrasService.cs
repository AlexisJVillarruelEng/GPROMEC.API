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
    public class ObrasService : IObrasService
    {
        private readonly IObrasRepository _repository;

        public ObrasService(IObrasRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        public async Task<IEnumerable<ObraDTO>> GetAllAsync()
        {
            var obras = await _repository.GetAllAsync();
            return obras.Select(o => new ObraDTO
            {
                IdObra = o.IdObra,
                NombreObra = o.NombreObra,
                Ubicacion = o.Ubicacion,
                FechaInicio = o.FechaInicio,
                FechaFin = o.FechaFin,
                NombreProyecto = o.IdProyectoNavigation.NombreProyecto
            });
        }

        public async Task<ObraDTO?> GetByIdAsync(int id)
        {
            var obra = await _repository.GetByIdAsync(id);
            if (obra == null) return null;

            return new ObraDTO
            {
                IdObra = obra.IdObra,
                NombreObra = obra.NombreObra,
                Ubicacion = obra.Ubicacion,
                FechaInicio = obra.FechaInicio,
                FechaFin = obra.FechaFin,
                NombreProyecto = obra.IdProyectoNavigation.NombreProyecto
            };
        }

        public async Task<int> AddAsync(CrearObraDTO obraDto)
        {
            var obra = new Obras
            {
                NombreObra = obraDto.NombreObra,
                Ubicacion = obraDto.Ubicacion,
                FechaInicio = obraDto.FechaInicio,
                FechaFin = obraDto.FechaFin,
                IdProyecto = obraDto.IdProyecto
            };

            return await _repository.AddAsync(obra);
        }

        public async Task UpdateAsync(CrearObraDTO obraDto, int id)
        {
            var obra = new Obras
            {
                IdObra = id,
                NombreObra = obraDto.NombreObra,
                Ubicacion = obraDto.Ubicacion,
                FechaInicio = obraDto.FechaInicio,
                FechaFin = obraDto.FechaFin,
                IdProyecto = obraDto.IdProyecto
            };

            await _repository.UpdateAsync(obra);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Obras>> ObtenerObrasPorProyectoAsync(int idProyecto)
        {
            return await _repository.ObtenerObrasPorProyectoAsync(idProyecto);
        }
    }
}
