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
    public class FirmasAtsProcesosRepository : IFirmasAtsProcesosRepository
    {
        private readonly GdbContext _context;
        public FirmasAtsProcesosRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FirmasAtsProcesos>> GetAllAsync() =>
            await _context.Set<FirmasAtsProcesos>().ToListAsync();

        public async Task<FirmasAtsProcesos?> GetByIdAsync(int id) =>
            await _context.Set<FirmasAtsProcesos>().FindAsync(id);

        public async Task<FirmasAtsProcesos> AddAsync(FirmasAtsProcesos entity)
        {
            _context.Set<FirmasAtsProcesos>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, FirmasAtsProcesos entity)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("Firma ATS Proceso no encontrada");
            _context.Entry(exist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist is null)
                throw new Exception("Firma ATS Proceso no encontrada");
            _context.Set<FirmasAtsProcesos>().Remove(exist);
            await _context.SaveChangesAsync();
        }
    }
}
