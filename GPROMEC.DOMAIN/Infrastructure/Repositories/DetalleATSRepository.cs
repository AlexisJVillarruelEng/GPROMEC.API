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
    public class DetalleATSRepository : IDetalleATSRepository
    {
        private readonly GdbContext _context;
        public DetalleATSRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleAts>> GetAllAsync() =>
            await _context.Set<DetalleAts>().ToListAsync();

        public async Task<DetalleAts?> GetByIdAsync(int id) =>
        await _context.Set<DetalleAts>().FindAsync(id);

        public async Task<DetalleAts> AddAsync(DetalleAts entity)
        {
            _context.Set<DetalleAts>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, DetalleAts entity)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("DetalleATS no encontrado");
            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("DetalleATS no encontrado");
            _context.Set<DetalleAts>().Remove(exist);
            await _context.SaveChangesAsync();
        }
    }
}
