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
    public class ProcesosRepository : IProcesosRepository
    {
        private readonly GdbContext _context;

        public ProcesosRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto.
        }

        public async Task<IEnumerable<Procesos>> GetAllAsync()
        {
            // Obtiene todos los procesos junto con la información de la partida relacionada.
            return await _context.Procesos.Include(p => p.IdPartidaNavigation).ToListAsync();
        }

        public async Task<Procesos?> GetByIdAsync(int id)
        {
            // Busca un proceso específico por su ID.
            return await _context.Procesos.Include(p => p.IdPartidaNavigation).FirstOrDefaultAsync(p => p.IdProceso == id);
        }

        public async Task<int> AddAsync(Procesos proceso)
        {
            // Agrega un nuevo proceso a la base de datos.
            _context.Procesos.Add(proceso);
            await _context.SaveChangesAsync();
            return proceso.IdProceso; // Retorna el ID generado automáticamente.
        }

        public async Task UpdateAsync(Procesos proceso)
        {
            // Actualiza un proceso existente.
            _context.Procesos.Update(proceso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Busca el proceso por ID y lo elimina si existe.
            var proceso = await _context.Procesos.FindAsync(id);
            if (proceso != null)
            {
                _context.Procesos.Remove(proceso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
