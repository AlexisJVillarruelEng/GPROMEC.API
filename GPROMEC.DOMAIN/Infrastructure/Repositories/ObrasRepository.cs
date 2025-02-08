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
    public class ObrasRepository : IObrasRepository
    {
        private readonly GdbContext _context;

        public ObrasRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto.
        }

        public async Task<IEnumerable<Obras>> GetAllAsync()
        {
            // Obtiene todas las obras junto con los datos del proyecto relacionado.
            return await _context.Obras
                .Include(o => o.IdProyectoNavigation)
                .ToListAsync();
        }

        public async Task<Obras?> GetByIdAsync(int id)
        {
            // Obtiene una obra por su ID junto con los datos del proyecto relacionado.
            return await _context.Obras
                .Include(o => o.IdProyectoNavigation)
                .FirstOrDefaultAsync(o => o.IdObra == id);
        }

        public async Task<int> AddAsync(Obras obra)
        {
            // Agrega una nueva obra.
            await _context.Obras.AddAsync(obra);
            await _context.SaveChangesAsync(); // Guarda los cambios.
            return obra.IdObra; // Retorna el ID generado.
        }

        public async Task UpdateAsync(Obras obra)
        {
            // Actualiza una obra existente.
            _context.Obras.Update(obra);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Elimina una obra permanentemente.
            var obra = await _context.Obras.FindAsync(id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Obras>> ObtenerObrasPorProyectoAsync(int idProyecto)
        {
            return await _context.Obras
                .Where(o => o.IdProyecto == idProyecto)
                .ToListAsync();
        }
    }
}
