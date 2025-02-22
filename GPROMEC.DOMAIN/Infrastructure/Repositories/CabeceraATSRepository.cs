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
    public class CabeceraATSRepository : ICabeceraATSRepository
    {
        private readonly GdbContext _context;
        public CabeceraATSRepository(GdbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CabeceraAts>> GetAllAsync() =>
            await _context.Set<CabeceraAts>().ToListAsync();

        public async Task<CabeceraAts?> GetByIdAsync(int id) =>
        await _context.Set<CabeceraAts>().FindAsync(id);

        public async Task<CabeceraAts> AddAsync(CabeceraAts entity)
        {
            _context.Set<CabeceraAts>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, CabeceraAts entity)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("No se encontró la cabecera ATS");
            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("No se encontró la cabecera ATS");
            _context.Set<CabeceraAts>().Remove(exist);
            await _context.SaveChangesAsync();
        }
    }
}
