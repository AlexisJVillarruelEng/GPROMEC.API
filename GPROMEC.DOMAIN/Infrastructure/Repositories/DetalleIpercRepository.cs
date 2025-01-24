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
    public class DetalleIpercRepository : IDetalleIpercRepository
    {
        private readonly GdbContext _context;

        public DetalleIpercRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto.
        }

        public async Task<IEnumerable<DetalleIperc>> GetAllAsync()
        {
            // Obtiene todos los registros de la tabla.
            return await _context.DetalleIperc.ToListAsync();
        }

        public async Task<DetalleIperc> GetByIdAsync(int id)
        {
            // Obtiene un registro por su ID.
            return await _context.DetalleIperc.FindAsync(id);
        }

        public async Task<int> AddAsync(DetalleIperc detalle)
        {
            // Agrega un nuevo registro al contexto.
            await _context.DetalleIperc.AddAsync(detalle);
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos.
            return detalle.IdDetalle; // Retorna el ID generado.
        }

        public async Task UpdateAsync(DetalleIperc detalle)
        {
            // Actualiza un registro existente.
            _context.DetalleIperc.Update(detalle);
            await _context.SaveChangesAsync(); // Guarda los cambios.
        }

        public async Task DeleteAsync(int id)
        {
            // Elimina un registro por ID.
            var detalle = await GetByIdAsync(id);
            if (detalle != null)
            {
                _context.DetalleIperc.Remove(detalle);
                await _context.SaveChangesAsync(); // Guarda los cambios.
            }
        }
    }
}
