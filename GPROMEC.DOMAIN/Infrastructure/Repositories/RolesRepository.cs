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
    public class RolesRepository : IRolesRepository
    {
        private readonly GdbContext _context; // Contexto de la base de datos.

        public RolesRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto.
        }

        // Obtener todos los registros.
        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        // Obtener un registro por su ID.
        public async Task<Roles> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        // Insertar un nuevo registro.
        public async Task AddAsync(Roles rol)
        {
            await _context.Roles.AddAsync(rol); // Agrega el rol al contexto.
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos.
        }

        // Actualizar un registro existente.
        public async Task UpdateAsync(Roles rol)
        {
            _context.Roles.Update(rol); // Marca el registro como modificado.
            await _context.SaveChangesAsync(); // Aplica los cambios en la base de datos.
        }

        // Eliminar un registro por su ID.
        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Roles.FindAsync(id); // Busca el registro.
            if (rol != null) // Si existe, lo elimina.
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync(); // Aplica los cambios.
            }
        }
    }
}
