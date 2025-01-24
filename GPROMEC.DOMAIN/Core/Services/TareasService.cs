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
    public class TareasService : ITareasService
    {
        private readonly ITareasRepository _repository;

        public TareasService(ITareasRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        public async Task<IEnumerable<TareaDTO>> GetAllAsync()
        {
            var tareas = await _repository.GetAllAsync();

            // Convierte las entidades a DTOs.
            return tareas.Select(t => new TareaDTO
            {
                IdTarea = t.IdTarea,
                NombreTarea = t.NombreTarea,
                TareaTipo = t.TareaTipo,
                IdProceso = t.IdProcesoNavigation?.IdProceso,
                NombreProceso = t.IdProcesoNavigation?.NombreProceso
            });
        }

        public async Task<TareaDTO?> GetByIdAsync(int id)
        {
            var tarea = await _repository.GetByIdAsync(id);
            if (tarea == null) return null;

            // Convierte la entidad a DTO.
            return new TareaDTO
            {
                IdTarea = tarea.IdTarea,
                NombreTarea = tarea.NombreTarea,
                TareaTipo = tarea.TareaTipo,
                IdProceso = tarea.IdProcesoNavigation?.IdProceso,
                NombreProceso = tarea.IdProcesoNavigation?.NombreProceso
            };
        }

        public async Task<int> AddAsync(CrearTareaDTO tareaDto)
        {
            var tarea = new Tareas
            {
                NombreTarea = tareaDto.NombreTarea,
                TareaTipo = tareaDto.TareaTipo,
                IdProceso = tareaDto.IdProceso
            };

            return await _repository.AddAsync(tarea);
        }

        public async Task UpdateAsync(CrearTareaDTO tareaDto, int id)
        {
            var tarea = new Tareas
            {
                IdTarea = id,
                NombreTarea = tareaDto.NombreTarea,
                TareaTipo = tareaDto.TareaTipo,
                IdProceso = tareaDto.IdProceso
            };

            await _repository.UpdateAsync(tarea);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
