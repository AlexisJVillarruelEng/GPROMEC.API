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
    public class TrabajadoresService : ITrabajadoresService
    {
        private readonly ITrabajadoresRepository _repository;

        public TrabajadoresService(ITrabajadoresRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TrabajadorDTO>> GetAllAsync(bool incluirInactivos = false)
        {
            var trabajadores = await _repository.GetAllAsync(incluirInactivos);
            return trabajadores.Select(t => new TrabajadorDTO
            {
                IdTrabajador = t.IdTrabajador,
                Nombre = t.Nombre,
                Apellido = t.Apellido,
                Correo = t.Correo,
                Departamento = t.IdUbigeoNavigation.Departamento,
                Rol = t.IdRolNavigation.NombreRol,
                Estado = t.Estado
            });
        }

        public async Task<TrabajadorDTO> GetByIdAsync(int id)
        {
            var trabajador = await _repository.GetByIdAsync(id);
            if (trabajador == null) return null;

            return new TrabajadorDTO
            {
                IdTrabajador = trabajador.IdTrabajador,
                Nombre = trabajador.Nombre,
                Apellido = trabajador.Apellido,
                Correo = trabajador.Correo,
                Rol = trabajador.IdRolNavigation.NombreRol,
                Estado = trabajador.Estado
            };
        }

        public async Task<int> AddAsync(CrearTrabajadorDTO trabajadorDto)
        {
            var trabajador = new Trabajadores
            {
                Nombre = trabajadorDto.Nombre,
                Apellido = trabajadorDto.Apellido,
                Dni = trabajadorDto.Dni,
                Correo = trabajadorDto.Correo,
                Contraseña = trabajadorDto.Contraseña,
                IdUbigeo = trabajadorDto.IdUbigeo,
                IdRol = trabajadorDto.IdRol,
                FechaCreacion = DateOnly.FromDateTime(DateTime.UtcNow),
                Estado = true
            };

            return await _repository.AddAsync(trabajador);
        }

        public async Task<string> IniciarSesionAsync(InicioSesionDTO inicioSesionDto)
        {
            var trabajador = await _repository.GetByCorreoAsync(inicioSesionDto.Correo);
            if (trabajador != null && trabajador.Contraseña == inicioSesionDto.Contraseña)
            {
                return trabajador.Nombre; // Retorna el nombre si las credenciales son correctas.
            }

            return null; // Credenciales inválidas.
        }

        public async Task UpdateAsync(CrearTrabajadorDTO trabajadorDto, int id)
        {
            var trabajador = new Trabajadores
            {
                IdTrabajador = id,
                Nombre = trabajadorDto.Nombre,
                Apellido = trabajadorDto.Apellido,
                Dni = trabajadorDto.Dni,
                Correo = trabajadorDto.Correo,
                Contraseña = trabajadorDto.Contraseña,
                IdUbigeo = trabajadorDto.IdUbigeo,
                IdRol = trabajadorDto.IdRol,
                FechaCreacion = DateOnly.FromDateTime(DateTime.UtcNow),
                Estado = true
            };

            await _repository.UpdateAsync(trabajador);
        }

        public async Task DeleteLogicallyAsync(int id)
        {
            await _repository.DeleteLogicallyAsync(id);
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            await _repository.DeletePermanentlyAsync(id);
        }
    }
}
