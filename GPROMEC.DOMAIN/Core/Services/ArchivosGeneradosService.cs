
using System.Data;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Validation;
using OfficeOpenXml;
using GPROMEC.DOMAIN.Core.DTO;
using System.IO.Compression;

namespace GPROMEC.DOMAIN.Core.Services
{
    public class ArchivosGeneradosService : IArchivosGeneradosService
    {
        private readonly IArchivosGeneradosRepository _repository;

        public ArchivosGeneradosService(IArchivosGeneradosRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CrearArchivoAsync(ArchivoGeneradoCrearDto archivoDto)
        {
            return await _repository.CrearArchivoAsync(archivoDto);
        }

        public async Task<byte[]> DescargarArchivoAsync(int id)
        {
            return await _repository.ObtenerArchivoBinarioAsync(id);
        }

        public async Task<byte[]> DescargarArchivosComoZipAsync(int proyectoId)
        {
            var archivos = await _repository.ObtenerArchivosPorProyectoAsync(proyectoId);
            return CrearArchivoZip(archivos);
        }

        public async Task<byte[]> DescargarArchivosPorCarpetaAsync(string carpeta)
        {
            var archivos = await _repository.ObtenerArchivosPorCarpetaAsync(carpeta);
            return CrearArchivoZip(archivos);
        }

        private byte[] CrearArchivoZip(List<ArchivoGeneradoDto> archivos)
        {
            using var memoryStream = new MemoryStream();
            using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var archivo in archivos)
                {
                    var entry = zip.CreateEntry(archivo.NombreArchivo);
                    using var entryStream = entry.Open();
                    entryStream.Write(archivo.Archivo, 0, archivo.Archivo.Length);
                }
            }
            return memoryStream.ToArray();
        }

        public async Task<int> ActualizarArchivoAsync(int id, ArchivoGeneradoCrearDto archivoDto, string generadoPor)
        {
            return await _repository.ActualizarArchivoAsync(id, archivoDto, generadoPor);
        }

        public async Task<ArchivoGeneradoDto> ObtenerArchivoPorIdAsync(int id)
        {
            return await _repository.ObtenerArchivoPorIdAsync(id);
        }

        public async Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorProyectoAsync(int proyectoId)
        {
            return await _repository.ObtenerArchivosPorProyectoAsync(proyectoId);
        }

        public async Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorCarpetaAsync(string carpeta)
        {
            return await _repository.ObtenerArchivosPorCarpetaAsync(carpeta);
        }
        public async Task<bool> EliminarLogicamenteAsync(int id)
        {
            return await _repository.EliminarLogicamenteAsync(id);
        }
    }
}
