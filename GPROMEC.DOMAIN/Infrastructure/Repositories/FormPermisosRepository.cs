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
    public class FormPermisoRepository : IFormPermisoRepository
    {
        private readonly GdbContext _context;

        public FormPermisoRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FormPermisos>> GetAllAsync() =>
            await _context.Set<FormPermisos>().ToListAsync();

        public async Task<FormPermisos?> GetByIdAsync(int id) =>
            await _context.Set<FormPermisos>().FindAsync(id);

        public async Task<FormPermisos> AddAsync(FormPermisos entity)
        {
            _context.Set<FormPermisos>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, FormPermisos entity)
        {
            var exist = await GetByIdAsync(id);
            if (exist == null)
                throw new Exception("Form Permiso not found");
            // Actualizamos los valores, excepto el id
            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist == null)
                throw new Exception("Form Permiso not found");
            _context.Set<FormPermisos>().Remove(exist);
            await _context.SaveChangesAsync();
        }
    }
}
