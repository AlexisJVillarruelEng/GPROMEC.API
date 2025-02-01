using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GPROMEC.DOMAIN.Infrastructure.Repositories
{
    public class FirmasMatrizIperRepository : IFirmasMatrizIperRepository
    {
        private readonly GdbContext _context;

        public FirmasMatrizIperRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FirmasMatrizIper>> GetAllAsync()
        {
            return await _context.FirmasMatrizIper
                .Include(f => f.ElaboradoPorNavigation)
                .Include(f => f.RevisadoPorNavigation)
                .Include(f => f.AprobadoPorNavigation)
                .ToListAsync();
        }

        public async Task<FirmasMatrizIper> GetByIdAsync(int id)
        {
            return await _context.FirmasMatrizIper
                .Include(f => f.ElaboradoPorNavigation)
                .Include(f => f.RevisadoPorNavigation)
                .Include(f => f.AprobadoPorNavigation)
                .FirstOrDefaultAsync(f => f.IdFirma == id);
        }

        public async Task<int> CreateAsync(FirmasMatrizIper firma)
        {
            await _context.FirmasMatrizIper.AddAsync(firma);
            await _context.SaveChangesAsync();
            return firma.IdFirma;
        }

        public async Task UpdateAsync(FirmasMatrizIper firma)
        {
            _context.FirmasMatrizIper.Update(firma);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var firma = await _context.FirmasMatrizIper.FindAsync(id);
            if (firma != null)
            {
                _context.FirmasMatrizIper.Remove(firma);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FirmasDTO>> ObtenerFirmasPorMatriz(int id_partida)
        {
            var firmas = await _context.FirmasMatrizIper
                .Where(f => f.IdPartida == id_partida)
                .Select(f => new FirmasDTO
                {
                    IdFirma = f.IdFirma,
                    NombreElaboradoPor = f.ElaboradoPorNavigation.Nombre,
                    NombreRevisadoPor = f.RevisadoPorNavigation.Nombre,
                    NombreAprobadoPor = f.AprobadoPorNavigation.Nombre,
                    FechaElaborado = f.FechaElaborado,
                    FechaRevisado = f.FechaRevisado,
                    FechaAprobado = f.FechaAprobado,
                    FirmaElaboradoUrl = f.FirmaElaboradoUrl ,
                    FirmaRevisadoUrl = f.FirmaRevisadoUrl,
                    FirmaAprobadoUrl = f.FirmaAprobadoUrl 
                })
                .ToListAsync();

            return firmas;
        }
    }
}
