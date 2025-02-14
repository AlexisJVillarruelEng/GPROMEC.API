using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPROMEC.DOMAIN.Core.DTO;
using GPROMEC.DOMAIN.Core.Entities;
using GPROMEC.DOMAIN.Core.Interfaces;
using GPROMEC.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GPROMEC.DOMAIN.Infrastructure.Repositories
{
    public class ArchivosGeneradosRepository : IArchivosGeneradosRepository
    {
        private readonly GdbContext _context;

        public ArchivosGeneradosRepository(GdbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ArchivoGeneradoDto>> GetAllAsync()
        {
            var entities = await _context.ArchivosGenerados.ToListAsync();
            var dtos = entities.Select(entity => new ArchivoGeneradoDto
            {
                IdArchivo = entity.IdArchivo,
                IdRelacion = (int)entity.IdRelacion,
                TablaRelacion = entity.TablaRelacion,
                Carpeta = entity.Carpeta,
                NombreArchivo = entity.NombreArchivo,
                GeneradoPor = entity.GeneradoPor,
                Archivo = entity.UrlArchivo
            });
            return dtos;
        }
        public async Task<int> CrearArchivoAsync(ArchivoGeneradoCrearDto archivoDto)
        {
            var archivo = new ArchivosGenerados
            {
                IdRelacion = archivoDto.IdRelacion,
                TablaRelacion = archivoDto.TablaRelacion,
                Carpeta = archivoDto.Carpeta,
                NombreArchivo = archivoDto.NombreArchivo,
                UrlArchivo = archivoDto.Archivo,
                FechaGeneracion = DateTime.UtcNow,
                GeneradoPor = archivoDto.GeneradoPor,
                Estado = true
            };

            _context.ArchivosGenerados.Add(archivo);
            await _context.SaveChangesAsync();
            return archivo.IdArchivo;
        }
         
        public async Task<byte[]> ObtenerArchivoBinarioAsync(int id)
        {
            var archivo = await _context.ArchivosGenerados.FindAsync(id);
            return archivo?.UrlArchivo;
        }

        public async Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorProyectoAsync(int proyectoId)
        {
            return await _context.ArchivosGenerados
                .Where(a => a.IdRelacion == proyectoId && a.Estado == true)
                .Select(a => new ArchivoGeneradoDto
                {
                    IdArchivo = a.IdArchivo,
                    NombreArchivo = a.NombreArchivo,
                    Archivo = a.UrlArchivo
                })
                .ToListAsync();
        }

        public async Task<List<ArchivoGeneradoDto>> ObtenerArchivosPorCarpetaAsync(string carpeta)
        {
            return await _context.ArchivosGenerados
                .Where(a => a.Carpeta == carpeta && a.Estado == true)
                .Select(a => new ArchivoGeneradoDto
                {
                    IdArchivo = a.IdArchivo,
                    NombreArchivo = a.NombreArchivo,
                    Archivo = a.UrlArchivo
                })
                .ToListAsync();
        }

        public async Task<bool> EliminarLogicamenteAsync(int id)
        {
            var archivo = await _context.ArchivosGenerados.FindAsync(id);
            if (archivo == null) return false;

            archivo.Estado = false;
            _context.ArchivosGenerados.Update(archivo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> ActualizarArchivoAsync(int id, ArchivoGeneradoCrearDto archivoDto, string generadoPor)
        {
            var archivo = await _context.ArchivosGenerados.FindAsync(id);
            if (archivo == null) throw new Exception("Archivo no encontrado");

            archivo.IdRelacion = archivoDto.IdRelacion;
            archivo.TablaRelacion = archivoDto.TablaRelacion;
            archivo.Carpeta = archivoDto.Carpeta;
            archivo.NombreArchivo = archivoDto.NombreArchivo;
            archivo.UrlArchivo = archivoDto.Archivo;
            archivo.FechaGeneracion = DateTime.UtcNow;
            archivo.GeneradoPor = generadoPor;

            _context.ArchivosGenerados.Update(archivo);
            await _context.SaveChangesAsync();
            return archivo.IdArchivo;
        }

        public async Task<ArchivoGeneradoDto> ObtenerArchivoPorIdAsync(int id)
        {
            var archivo = await _context.ArchivosGenerados.FindAsync(id);
            if (archivo == null) return null;

            return new ArchivoGeneradoDto
            {
                IdArchivo = archivo.IdArchivo,
                IdRelacion = archivo.IdRelacion ?? 0,
                TablaRelacion = archivo.TablaRelacion,
                Carpeta = archivo.Carpeta,
                NombreArchivo = archivo.NombreArchivo,
                FechaGeneracion = archivo.FechaGeneracion ?? DateTime.UtcNow,
                GeneradoPor = archivo.GeneradoPor,
                Estado = archivo.Estado ?? false,
                Archivo = archivo.UrlArchivo
            };
        }
    }
}

