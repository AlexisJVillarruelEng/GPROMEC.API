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
    public class ProcesosService : IProcesosService
    {
        private readonly IProcesosRepository _repository;

        public ProcesosService(IProcesosRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        public async Task<IEnumerable<ProcesoDTO>> GetAllAsync()
        {
            // Obtiene todos los procesos del repositorio.
            var procesos = await _repository.GetAllAsync();

            // Convierte las entidades a DTOs.
            return procesos.Select(p => new ProcesoDTO
            {
                IdProceso = p.IdProceso,
                NombreProceso = p.NombreProceso,
                IdPartida = p.IdPartidaNavigation?.IdPartida,
                NombrePartida = p.IdPartidaNavigation?.NombrePartida
            });
        }

        public async Task<ProcesoDTO?> GetByIdAsync(int id)
        {
            // Obtiene un proceso por su ID.
            var proceso = await _repository.GetByIdAsync(id);
            if (proceso == null) return null;

            // Convierte la entidad a DTO.
            return new ProcesoDTO
            {
                IdProceso = proceso.IdProceso,
                NombreProceso = proceso.NombreProceso,
                IdPartida = proceso.IdPartidaNavigation?.IdPartida,
                NombrePartida = proceso.IdPartidaNavigation?.NombrePartida
            };
        }

        public async Task<int> AddAsync(CrearProcesoDTO dto)
        {
            // Crea una entidad a partir del DTO.
            var proceso = new Procesos
            {
                NombreProceso = dto.NombreProceso,
                IdPartida = dto.IdPartida
            };

            // Llama al repositorio para agregar el proceso.
            return await _repository.AddAsync(proceso);
        }

        public async Task UpdateAsync(CrearProcesoDTO dto, int id)
        {
            // Crea una entidad con los datos actualizados.
            var proceso = new Procesos
            {
                IdProceso = id,
                NombreProceso = dto.NombreProceso,
                IdPartida = dto.IdPartida
            };

            // Llama al repositorio para actualizar.
            await _repository.UpdateAsync(proceso);
        }

        public async Task DeleteAsync(int id)
        {
            // Llama al repositorio para eliminar físicamente.
            await _repository.DeleteAsync(id);
        }
    }
}
