using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;

namespace GPROMEC.DOMAIN.Core.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _repository;

        public ClientesService(IClientesRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            // Obtiene todos los clientes del repositorio.
            var clientes = await _repository.GetAllAsync();

            // Convierte las entidades a DTOs.
            return clientes.Select(c => new ClienteDTO
            {
                IdCliente = c.IdCliente,
                NombreCliente = c.NombreCliente,
                ContactoCliente = c.ContactoCliente,
                CorreoCliente = c.CorreoCliente,
                TelefonoCliente = c.TelefonoCliente
            });
        }

        public async Task<ClienteDTO> GetByIdAsync(int id)
        {
            // Obtiene un cliente por su ID.
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return null;

            // Convierte la entidad a DTO.
            return new ClienteDTO
            {
                IdCliente = cliente.IdCliente,
                NombreCliente = cliente.NombreCliente,
                ContactoCliente = cliente.ContactoCliente,
                CorreoCliente = cliente.CorreoCliente,
                TelefonoCliente = cliente.TelefonoCliente
            };
        }

        public async Task<int> AddAsync(CrearClienteDTO clienteDto)
        {
            // Crea una entidad a partir del DTO.
            var cliente = new Clientes
            {
                NombreCliente = clienteDto.NombreCliente,
                ContactoCliente = clienteDto.ContactoCliente,
                CorreoCliente = clienteDto.CorreoCliente,
                TelefonoCliente = clienteDto.TelefonoCliente
            };

            // Llama al repositorio para agregar el cliente.
            return await _repository.AddAsync(cliente);
        }

        public async Task UpdateAsync(CrearClienteDTO clienteDto, int id)
        {
            // Crea una entidad a partir del DTO y asigna el ID.
            var cliente = new Clientes
            {
                IdCliente = id,
                NombreCliente = clienteDto.NombreCliente,
                ContactoCliente = clienteDto.ContactoCliente,
                CorreoCliente = clienteDto.CorreoCliente,
                TelefonoCliente = clienteDto.TelefonoCliente
            };

            // Llama al repositorio para actualizar el cliente.
            await _repository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            // Llama al repositorio para eliminar físicamente el cliente.
            await _repository.DeleteAsync(id);
        }
    }
}
