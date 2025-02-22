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
    public class DetallePermisosGeneralRepository : IDetallePermisosGeneralRepository
    {
        private readonly GdbContext _context;

        public DetallePermisosGeneralRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetallePermisosGeneral>> GetAllAsync()
        {
            return await _context.DetallePermisosGeneral.ToListAsync();
        }

        public async Task<DetallePermisosGeneral?> GetByIdAsync(int id)
        {
            return await _context.DetallePermisosGeneral.FindAsync(id);
        }

        public async Task<DetallePermisosGeneral> AddAsync(DetallePermisosGeneral entity)
        {
            _context.DetallePermisosGeneral.Add(entity);
            await _context.SaveChangesAsync();
            return entity; // Se retorna la entidad creada (con el id generado)
        }

        public async Task UpdateAsync(DetallePermisosGeneral entity)
        {
            _context.DetallePermisosGeneral.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.DetallePermisosGeneral.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
