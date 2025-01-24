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
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _repository; // Repositorio de Roles.

        public RolesService(IRolesRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        // Obtener todos los registros como DTO.
        public async Task<IEnumerable<RolesDTO>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync(); // Obtiene los datos del repositorio.
            return roles.Select(r => new RolesDTO // Convierte cada entidad a DTO.
            {
                IdRol = r.IdRol,
                NombreRol = r.NombreRol
            });
        }

        // Obtener un registro por ID como DTO.
        public async Task<RolesDTO> GetByIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id); // Busca el registro en el repositorio.
            if (rol == null) return null; // Retorna null si no existe.

            return new RolesDTO // Convierte la entidad a DTO.
            {
                IdRol = rol.IdRol,
                NombreRol = rol.NombreRol
            };
        }

        // Insertar un nuevo registro desde un DTO.
        public async Task AddAsync(RolesDTO rolDto)
        {
            var rol = new Roles
            {
                NombreRol = rolDto.NombreRol
            };

            await _repository.AddAsync(rol); // Inserta el registro en el repositorio.
        }

        // Actualizar un registro existente desde un DTO.
        public async Task UpdateAsync(RolesDTO rolDto)
        {
            var rol = new Roles
            {
                IdRol = rolDto.IdRol,
                NombreRol = rolDto.NombreRol
            };

            await _repository.UpdateAsync(rol); // Actualiza el registro.
        }

        // Eliminar un registro por su ID.
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id); // Llama al repositorio para eliminar.
        }
    }
}
