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
    public class PartidasRepository : IPartidasRepository
    {
        private readonly GdbContext _context;

        public PartidasRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto.
        }

        public async Task<IEnumerable<Partidas>> GetAllAsync()
        {
            // Obtiene todas las partidas, incluyendo datos de la obra relacionada.
            return await _context.Partidas.Include(p => p.IdObraNavigation).ToListAsync();
        }

        public async Task<Partidas?> GetByIdAsync(int id)
        {
            // Obtiene una partida específica por ID.
            return await _context.Partidas.Include(p => p.IdObraNavigation).FirstOrDefaultAsync(p => p.IdPartida == id);
        }

        public async Task<int> AddAsync(Partidas partida)
        {
            // Agrega una nueva partida.
            _context.Partidas.Add(partida);
            await _context.SaveChangesAsync();
            return partida.IdPartida; // Retorna el ID generado.
        }

        public async Task UpdateAsync(Partidas partida)
        {
            // Actualiza una partida existente.
            _context.Partidas.Update(partida);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Elimina una partida de forma permanente.
            var partida = await _context.Partidas.FindAsync(id);
            if (partida != null)
            {
                _context.Partidas.Remove(partida);
                await _context.SaveChangesAsync();
            }
        }
    }
}
