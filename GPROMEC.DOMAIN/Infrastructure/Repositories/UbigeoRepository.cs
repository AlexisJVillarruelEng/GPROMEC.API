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
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly GdbContext _dbContext;

        public UbigeoRepository(GdbContext context)
        {
            _dbContext = context; //inyeccion
        }

        public async Task<IEnumerable<Ubigeo>> GetAllAsync()
        {
            return await _dbContext.Ubigeo.ToListAsync();
        }

        public async Task<Ubigeo> GetByIdAsync(int id)
        {
            return await _dbContext.Ubigeo.FindAsync(id);
        }

        public async Task<int> AddAsync(Ubigeo ubigeo)
        {
            await _dbContext.Ubigeo.AddAsync(ubigeo);
            await _dbContext.SaveChangesAsync();
            return ubigeo.IdUbigeo;
        }

        public async Task UpdateAsync(Ubigeo ubigeo)
        {
            _dbContext.Ubigeo.Update(ubigeo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ubigeo = await _dbContext.Ubigeo.FindAsync(id);
            if (ubigeo != null)
            {
                _dbContext.Ubigeo.Remove(ubigeo);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

        
