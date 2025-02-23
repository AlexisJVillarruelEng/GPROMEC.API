using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GPROMEC.DOMAIN.Infrastructure.Repositories
{
    public class DetalleAtsRepository : IDetalleATSRepository
    {
        private readonly GdbContext _context;

        public DetalleAtsRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<DetalleAts> AddAsync(DetalleAts entity)
        {
            _context.DetalleAts.Add(entity);
            await _context.SaveChangesAsync();
            // Cargar la propiedad de navegación (opcional)
            await _context.Entry(entity).Reference(e => e.IdDetalleipercNavigation).LoadAsync();
            return entity;
        }

        public async Task<IEnumerable<DetalleAts>> GetAllAsync() =>
            await _context.DetalleAts
                .Include(x => x.IdDetalleipercNavigation)
                .ToListAsync();

        public async Task<DetalleAts?> GetByIdAsync(int id) =>
            await _context.DetalleAts
                .Include(x => x.IdDetalleipercNavigation)
                .FirstOrDefaultAsync(x => x.IdDetalleAts == id);

        public async Task UpdateAsync(int id, DetalleAts entity)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("No existe DetalleATS con ese id.");

            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("No existe DetalleATS con ese id.");
            _context.DetalleAts.Remove(exist);
            await _context.SaveChangesAsync();
        }
    }
}
