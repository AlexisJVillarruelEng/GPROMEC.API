using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GPROMEC.DOMAIN.Infrastructure.Repositories
{
    public class TareasRepository : ITareasRepository
    {
        private readonly GdbContext _context;

        public TareasRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto de la base de datos.
        }

        public async Task<IEnumerable<Tareas>> GetAllAsync()
        {
            // Obtiene todas las tareas junto con el proceso relacionado.
            return await _context.Tareas.Include(t => t.IdProcesoNavigation).ToListAsync();
        }

        public async Task<Tareas?> GetByIdAsync(int id)
        {
            // Busca una tarea específica por su ID.
            return await _context.Tareas.Include(t => t.IdProcesoNavigation).FirstOrDefaultAsync(t => t.IdTarea == id);
        }

        public async Task<int> AddAsync(Tareas tarea)
        {
            // Agrega una nueva tarea al contexto.
            await _context.Tareas.AddAsync(tarea);
            await _context.SaveChangesAsync(); // Guarda los cambios.
            return tarea.IdTarea; // Retorna el ID generado.
        }

        public async Task UpdateAsync(Tareas tarea)
        {
            // Actualiza los datos de una tarea existente.
            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Busca la tarea por ID y la elimina si existe.
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
