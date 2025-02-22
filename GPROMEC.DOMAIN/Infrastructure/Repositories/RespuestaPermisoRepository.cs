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
    public class RespuestaPermisosRepository : IRespuestaPermisosRepository
    {
        private readonly GdbContext _context;
        public RespuestaPermisosRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RespuestaPermisos>> GetAllAsync() =>
            await _context.Set<RespuestaPermisos>().ToListAsync();

        public async Task<RespuestaPermisos?> GetByIdAsync(int id) =>
            await _context.Set<RespuestaPermisos>().FindAsync(id);

        public async Task<RespuestaPermisos> AddAsync(RespuestaPermisos entity)
        {
            _context.Set<RespuestaPermisos>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, RespuestaPermisos entity)
        {
            var exist = await GetByIdAsync(id);
            if (exist == null)
                throw new Exception("Respuesta Permiso no encontrado");

            // Actualizamos sólo los campos que se desean modificar (sin cambiar la llave Identity)
            exist.IdForm = entity.IdForm;
            exist.IdCabeceraPermisos = entity.IdCabeceraPermisos;
            exist.Respuesta = entity.Respuesta;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist == null)
                throw new Exception("Respuesta Permiso no encontrado");

            _context.Set<RespuestaPermisos>().Remove(exist);
            await _context.SaveChangesAsync();
        }
    }
}
