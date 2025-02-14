
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GPROMEC.API.Controllers
{
    [Route("gpromecAPIv1/[controller]")]
    [ApiController]
    public class ArchivosGeneradosController : ControllerBase
    {
        private readonly IArchivosGeneradosService _service;

        public ArchivosGeneradosController(IArchivosGeneradosService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchivoGeneradoDto>>> GetAll()
        {
            var archivos = await _service.GetAllAsync();
            return Ok(archivos);
        }

        [HttpPost]
        public async Task<IActionResult> SubirArchivo([FromBody] ArchivoGeneradoCrearDto archivoDto)
        {
            if (archivoDto == null || archivoDto.Archivo == null || archivoDto.Archivo.Length == 0)
            {
                return BadRequest("Debe proporcionar un archivo válido.");
            }


            var id = await _service.CrearArchivoAsync(archivoDto);

            return Ok(new { Id = id, GeneradoPor = archivoDto.GeneradoPor, Fecha = DateTime.UtcNow });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DescargarArchivo(int id)
        {
            var archivo = await _service.ObtenerArchivoPorIdAsync(id);
            if (archivo == null || archivo.Archivo == null)
            {
                return NotFound("Archivo no encontrado.");
            }

            // Convertir Base64 a byte[]
            var archivoBytes = archivo.Archivo;

            var tipoMime = archivo.NombreArchivo.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)
                ? "application/pdf"
                : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(archivoBytes, tipoMime, archivo.NombreArchivo);
        }

        [HttpGet("proyecto/{proyectoId}")]
        public async Task<IActionResult> DescargarArchivosPorProyecto(int proyectoId)
        {
            var archivos = await _service.ObtenerArchivosPorProyectoAsync(proyectoId);

            if (archivos == null || !archivos.Any())
            {
                return NotFound("No se encontraron archivos para el proyecto especificado.");
            }

            var zipBytes = await _service.DescargarArchivosComoZipAsync(proyectoId);

            return Ok(new
            {
                ArchivoZip = Convert.ToBase64String(zipBytes),
                Archivos = archivos.Select(a => new { a.NombreArchivo, a.GeneradoPor }).ToList()
            });
        }
        [HttpGet("carpeta/{carpeta}")]
        public async Task<IActionResult> DescargarArchivosPorCarpeta(string carpeta)
        {
            var archivos = await _service.ObtenerArchivosPorCarpetaAsync(carpeta);

            if (archivos == null || !archivos.Any())
            {
                return NotFound("No se encontraron archivos en la carpeta especificada.");
            }

            var zipBytes = await _service.DescargarArchivosPorCarpetaAsync(carpeta);

            return Ok(new
            {
                ArchivoZip = Convert.ToBase64String(zipBytes),
                Archivos = archivos.Select(a => new { a.NombreArchivo, a.GeneradoPor }).ToList()
            });
        }

    }
}


