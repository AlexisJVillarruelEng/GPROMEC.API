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
    public class ClientesRepository : IClientesRepository
    {
        private readonly GdbContext _context;

        public ClientesRepository(GdbContext context)
        {
            _context = context; // Inyección del contexto.
        }

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            // Obtiene todos los clientes.
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetByIdAsync(int id)
        {
            // Busca un cliente por su ID.
            return await _context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        public async Task<int> AddAsync(Clientes cliente)
        {
            // Agrega un nuevo cliente y guarda los cambios.
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente.IdCliente; // Devuelve el ID generado.
        }

        public async Task UpdateAsync(Clientes cliente)
        {
            // Actualiza los datos de un cliente existente.
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Elimina físicamente un cliente por su ID.
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}