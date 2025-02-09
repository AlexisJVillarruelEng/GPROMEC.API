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
    public class ProyectosRepository : IProyectosRepository
    {
        private readonly GdbContext _context;

        public ProyectosRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto.
        }

        public async Task<IEnumerable<Proyectos>> GetAllAsync(bool incluirInactivos = false)
        {
            // Obtiene los proyectos según el estado.
            return await _context.Proyectos
                .Where(p => incluirInactivos || p.Estado) // Filtra activos/inactivos.
                .Include(p => p.IdClienteNavigation) // Incluye los datos del cliente relacionado.
                .ToListAsync();
        }

        public async Task<Proyectos> GetByIdAsync(int id)
        {
            // Obtiene un proyecto por su ID.
            return await _context.Proyectos
                .Include(p => p.IdClienteNavigation) // Incluye los datos del cliente relacionado.
                .FirstOrDefaultAsync(p => p.IdProyecto == id);
        }

        public async Task<int> AddAsync(Proyectos proyecto)
        {
            // Agrega un nuevo proyecto y guarda los cambios.
            await _context.Proyectos.AddAsync(proyecto);
            await _context.SaveChangesAsync();
            return proyecto.IdProyecto; // Retorna el ID generado.
        }

        public async Task UpdateAsync(Proyectos proyecto)
        {
            // Actualiza los datos de un proyecto existente.
            _context.Proyectos.Update(proyecto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogicallyAsync(int id)
        {
            // Cambia el estado de un proyecto a inactivo.
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                proyecto.Estado = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            // Elimina físicamente un proyecto por su ID.
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Proyectos>> ObtenerProyectosPorCliente(int idCliente)
        {
            return await _context.Proyectos
                .Where(p => p.IdCliente == idCliente)
                .ToListAsync();
        }
    }
}
