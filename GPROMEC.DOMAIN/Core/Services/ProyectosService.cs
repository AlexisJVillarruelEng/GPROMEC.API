using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;

using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using GPROMEC.DOMAIN.Infrastructure.Repositories;

namespace GPROMEC.DOMAIN.Core.Services
{
    public class ProyectosService : IProyectosService
    {
        private readonly IProyectosRepository _repository;

        public ProyectosService(IProyectosRepository repository)
        {
            _repository = repository; // Inyección del repositorio.
        }

        public async Task<IEnumerable<ProyectoDTO>> GetAllAsync(bool incluirInactivos = false)
        {
            // Obtiene los proyectos del repositorio.
            var proyectos = await _repository.GetAllAsync(incluirInactivos);

            // Convierte las entidades a DTOs.
            return proyectos.Select(p =>
            {

                return new ProyectoDTO
                {
                    IdProyecto = p.IdProyecto,
                    NombreProyecto = p.NombreProyecto,
                    Descripcion = p.Descripcion,
                    FechaInicio = p.FechaInicio,
                    FechaFin = p.FechaFin,
                    Estado = p.Estado,
                    NombreCliente = p.IdClienteNavigation?.NombreCliente
                };
            });
        }

        public async Task<ProyectoDTO> GetByIdAsync(int id)
        {
            // Obtiene un proyecto por su ID.
            var proyecto = await _repository.GetByIdAsync(id);
            if (proyecto == null) return null;

            // Convierte la entidad a DTO.
            return new ProyectoDTO
            {
                IdProyecto = proyecto.IdProyecto,
                NombreProyecto = proyecto.NombreProyecto,
                Descripcion = proyecto.Descripcion,
                FechaInicio = proyecto.FechaInicio,
                FechaFin = proyecto.FechaFin,
                Estado = proyecto.Estado,
                NombreCliente = proyecto.IdClienteNavigation?.NombreCliente
            };
        }

        public async Task<int> AddAsync(CrearProyectoDTO proyectoDto)
        {
            // Crea una entidad a partir del DTO.
            var proyecto = new Proyectos
            {
                NombreProyecto = proyectoDto.NombreProyecto,
                Descripcion = proyectoDto.Descripcion,
                FechaInicio = proyectoDto.FechaInicio,
                FechaFin = proyectoDto.FechaFin,
                IdCliente = proyectoDto.IdCliente,
                Estado = true // Por defecto, los proyectos son activos.
            };

            // Llama al repositorio para agregar el proyecto.
            var proyectoID = await _repository.AddAsync(proyecto);
            //await CrearCarpetasEnFirebase(proyectoDto.NombreProyecto);
            return proyectoID;

        }


        public async Task UpdateAsync(CrearProyectoDTO proyectoDto, int id)
        {
            // Crea una entidad con los datos actualizados.
            var proyecto = new Proyectos
            {
                IdProyecto = id,
                NombreProyecto = proyectoDto.NombreProyecto,
                Descripcion = proyectoDto.Descripcion,
                FechaInicio = proyectoDto.FechaInicio,
                FechaFin = proyectoDto.FechaFin,
                IdCliente = proyectoDto.IdCliente,
                Estado = true // Asegura que siga activo tras la actualización.
            };

            // Llama al repositorio para actualizar.
            await _repository.UpdateAsync(proyecto);
        }

        public async Task DeleteLogicallyAsync(int id)
        {
            // Llama al repositorio para cambiar el estado a inactivo.
            await _repository.DeleteLogicallyAsync(id);
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            // Llama al repositorio para eliminar físicamente.
            await _repository.DeletePermanentlyAsync(id);
        }
        public async Task<IEnumerable<Proyectos>> ObtenerProyectosPorCliente(int idCliente)
        {
            return await _repository.ObtenerProyectosPorCliente(idCliente);
        }


        // Método para probar la conexión a Firebase.

    }
}
