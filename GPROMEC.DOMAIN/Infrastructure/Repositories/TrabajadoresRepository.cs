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
    public class TrabajadoresRepository : ITrabajadoresRepository
    {
        private readonly GdbContext _context;

        public TrabajadoresRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trabajadores>> GetAllAsync(bool incluirInactivos = false)
        {
            return await _context.Trabajadores
                .Where(t => incluirInactivos || t.Estado) // Filtra activos/inactivos según el parámetro.
                .Include(t => t.IdUbigeoNavigation)
                .Include(t => t.IdRolNavigation)
                .ToListAsync();
        }

        public async Task<Trabajadores> GetByIdAsync(int id)
        {
            return await _context.Trabajadores
                .Include(t => t.IdRolNavigation)
                .Include(t => t.IdUbigeoNavigation)
                .FirstOrDefaultAsync(t => t.IdTrabajador == id);
        }

        public async Task<Trabajadores> GetByCorreoAsync(string correo)
        {
            return await _context.Trabajadores
                   .Include(t => t.IdRolNavigation) // Incluye la información del rol
                   .FirstOrDefaultAsync(t => t.Correo == correo && t.Estado);
        }

        public async Task<int> AddAsync(Trabajadores trabajador)
        {
            await _context.Trabajadores.AddAsync(trabajador);
            await _context.SaveChangesAsync();
            return trabajador.IdTrabajador; // Retorna el ID generado.
        }

        public async Task<bool> UpdateAsync(int id, ActualizarTrabajadorDTO trabajadorDTO)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);

            if (trabajador == null)
            {
                return false;
            }

            trabajador.Nombre = trabajadorDTO.Nombre;
            trabajador.Apellido = trabajadorDTO.Apellido;
            trabajador.Dni = trabajadorDTO.DNI;
            trabajador.Correo = trabajadorDTO.Correo;
            trabajador.Contraseña = trabajadorDTO.Contraseña;
            trabajador.IdUbigeo = trabajadorDTO.IdUbigeo;
            trabajador.IdRol = trabajadorDTO.IdRol;
            trabajador.FechaCreacion = DateOnly.FromDateTime(DateTime.UtcNow);

            if (trabajadorDTO.Estado.HasValue)
            {
                trabajador.Estado = trabajadorDTO.Estado.Value;
            }

            _context.Trabajadores.Update(trabajador);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteLogicallyAsync(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador != null)
            {
                trabajador.Estado = false; // Cambia el estado a inactivo.
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var trabajador = await _context.Trabajadores.FindAsync(id);
            if (trabajador != null)
            {
                _context.Trabajadores.Remove(trabajador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
