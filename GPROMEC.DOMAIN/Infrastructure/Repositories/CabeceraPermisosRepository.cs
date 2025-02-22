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
    public class CabeceraPermisosRepository : ICabeceraPermisosRepository
    {
        private readonly GdbContext _context;

        public CabeceraPermisosRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CabeceraPermisos>> GetAllAsync()
        {
            return await _context.CabeceraPermisos.ToListAsync();
        }

        public async Task<CabeceraPermisos?> GetByIdAsync(int id)
        {
            return await _context.CabeceraPermisos
                .FirstOrDefaultAsync(x => x.IdCabeceraPermisos == id);
        }

        public async Task<CabeceraPermisos> AddAsync(CabeceraPermisos entity)
        {
            _context.CabeceraPermisos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(CabeceraPermisos entity)
        {
            _context.CabeceraPermisos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetByIdAsync(id);
            if (existing != null)
            {
                _context.CabeceraPermisos.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
