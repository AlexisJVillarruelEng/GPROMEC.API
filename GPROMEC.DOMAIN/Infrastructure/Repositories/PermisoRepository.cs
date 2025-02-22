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
    public class PermisoRepository : IPermisoRepository
    {
        private readonly GdbContext _context;
        public PermisoRepository(GdbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Permisos>> GetAllAsync() =>
            await _context.Set<Permisos>().ToListAsync();
        public async Task<Permisos?> GetByIdAsync(int id) =>
        await _context.Set<Permisos>().FindAsync(id);

        public async Task<Permisos> AddAsync(Permisos entity)
        {
            // Asegurarse de que el Id no tenga valor (o sea 0) para que la BD lo genere
            entity.IdPermiso = 0;
            _context.Set<Permisos>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, Permisos entity)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("Permiso no encontrado");
            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("Permiso no encontrado");
            _context.Set<Permisos>().Remove(exist);
            await _context.SaveChangesAsync();
        }
    }
}
