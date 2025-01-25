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

        //Firebase crear archivos
        private async Task CrearCarpetasEnFirebase(string nombreProyecto)
        {
            try
            {
                // Inicializa Firebase si aún no está inicializado.
                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions
                    {
                        Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "firebase-config.json")) // Ruta al archivo JSON de credenciales.
                    });
                }

                // Configurar el cliente de Google Cloud Storage.
                var storage = StorageClient.Create();
                var bucketName = "gs://gpproject-2c0a9.firebasestorage.app"; // Reemplaza con tu bucket de Firebase.

                // Crear archivos temporales en las "carpetas".
                var carpetaProyecto = $"Proyectos/{nombreProyecto}/";
                var carpetaFirmas = $"{carpetaProyecto}Firmas_{nombreProyecto}_MatricesIPERC/";
                var carpetaMatrices = $"{carpetaProyecto}Matrices_IPERC_{nombreProyecto}/";

                // Subir un archivo vacío a cada carpeta para que existan.
                using (var stream = new MemoryStream(new byte[0]))
                {
                    await storage.UploadObjectAsync(bucketName, $"{carpetaFirmas}placeholder.txt", "text/plain", stream);
                    await storage.UploadObjectAsync(bucketName, $"{carpetaMatrices}placeholder.txt", "text/plain", stream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear carpetas en Firebase: " + ex.Message);
            }
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
    

    // Método para probar la conexión a Firebase.
        public async Task ProbarConexionFirebase()
        {
            try
            {
                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions
                    {
                        Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "firebase-config.json"))
                    });
                }

                var storage = StorageClient.Create();
                var bucketName = "gpproject-2c0a9.appspot.com";

                var objetos = storage.ListObjects(bucketName);
                foreach (var obj in objetos)
                {
                    Console.WriteLine($"Archivo encontrado: {obj.Name}");
                }

                Console.WriteLine("Conexión a Firebase y listado de objetos exitosa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar con Firebase: {ex.Message}");
                throw new Exception("Error al conectar con Firebase: " + ex.Message);
            }

        }
    }
}
