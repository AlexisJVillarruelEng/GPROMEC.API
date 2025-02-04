using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Infrastructure.Repositories;

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
                Contraseña= t.Contraseña,
                FechaCreacion= t.FechaCreacion,
                Dni= t.Dni,
                Departamento = t.IdUbigeoNavigation.Departamento,
                Rol = t.IdRolNavigation.NombreRol,
                Estado = t.Estado,
                IdUbigeo = t.IdUbigeo,
                IdRol = t.IdRol
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
                Contraseña = trabajador.Contraseña,
                Dni = trabajador.Dni,
                Departamento = trabajador.IdUbigeoNavigation.Departamento?? "no info",
                Rol = trabajador.IdRolNavigation?.NombreRol,
                Estado = trabajador.Estado,
                IdUbigeo = trabajador.IdUbigeo,
                IdRol = trabajador.IdRol
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

        public async Task<LoginResponseDTO> IniciarSesionAsync(InicioSesionDTO inicioSesionDto)
        {
            var trabajador = await _repository.GetByCorreoAsync(inicioSesionDto.Correo);
            if (trabajador != null && trabajador.Contraseña == inicioSesionDto.Contraseña)
            {
                return new LoginResponseDTO
                {
                     Nombre = trabajador.Nombre,
                     Rol = trabajador.IdRolNavigation.NombreRol // Asume que IdRolNavigation contiene el rol
                }; // Retorna el nombre si las credenciales son correctas.
            }

            return null; // Credenciales inválidas.
        }

        public async Task<bool> UpdateAsync(int id, ActualizarTrabajadorDTO trabajadorDTO)
        {
            return await _repository.UpdateAsync(id, trabajadorDTO);
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
