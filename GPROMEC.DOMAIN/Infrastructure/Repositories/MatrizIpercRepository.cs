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
    public class MatrizIpercRepository : IMatrizIpercRepository
    {
        private readonly GdbContext _context;

        public MatrizIpercRepository(GdbContext context)
        {
            _context = context;
        }

        public async Task<MatrizIpercDTO> ObtenerMatrizPorPartida(int idPartida)
        {
            var matriz = await _context.Partidas
                .Where(p => p.IdPartida == idPartida)
                .Select(p => new MatrizIpercDTO
                {
                    IdPartida = p.IdPartida,
                    Procesos = p.Procesos.Select(proc => new ProcesosDTO
                    {
                        IdProceso = proc.IdProceso,
                        NombreProceso = proc.NombreProceso,
                        Tareas = proc.Tareas.Select(tar => new TareasDTO
                        {
                            IdTarea = tar.IdTarea,
                            NombreTarea = tar.NombreTarea,
                            DetallesIperc = tar.DetalleIperc.Select(det => new DetallesIpercDTO
                            {
                                IdDetalle = det.IdDetalle,
                                DescPeligros = det.DescPeligros,
                                TipoPeligro = det.TipoPeligro,
                                Riesgos = det.Riesgos,
                                TipoRiesgo = det.TipoRiesgo,
                                MedidaControlDescrip = det.MedidaControlDescrip,
                                PersonasExpuestas = det.PersonasExpuestas.GetValueOrDefault(),
                                ProcedimientosExistentes= det.ProcedimietntosExistentes.GetValueOrDefault(),
                                Capacitacion = det.Capacitacion.GetValueOrDefault(),
                                ExpoRiesgo = det.ExpoRiesgo.GetValueOrDefault(),
                                Probabilidad = det.Probabilidad.GetValueOrDefault(),
                                Severidad = det.Severidad.GetValueOrDefault(),
                                NivielDeRiesgo = det.NivielDeRiesgo.GetValueOrDefault(),
                                GradoRiesgo = det.GradoRiesgo
                            }).ToList()
                        }).ToList()
                    }).ToList(),
                    Firmas = p.FirmasMatrizIper.Select(f => new FirmaDTO
                    {
                        IdFirma = f.IdFirma,
                        IdPartida = f.IdPartida,
                        ElaboradoPor = f.ElaboradoPor,
                        RevisadoPor = f.RevisadoPor.GetValueOrDefault(),
                        AprobadoPor = f.AprobadoPor.GetValueOrDefault(),
                        FechaElaborado = f.FechaElaborado,
                        FechaRevisado = f.FechaRevisado,
                        FechaAprobado = f.FechaAprobado,
                        FirmaElaboradoBase64 = f.FirmaElaboradoUrl,
                        FirmaRevisadoBase64 = f.FirmaRevisadoUrl,
                        FirmaAprobadoBase64  =f.FirmaAprobadoUrl
                    }).FirstOrDefault()
                }).FirstOrDefaultAsync();

            return matriz;
        }

        public async Task<bool> ActualizarMatriz(MatrizIpercDTO matriz)
        {
            var partida = await _context.Partidas.FindAsync(matriz.IdPartida);
            if (partida == null) return false;

            // Actualizar lógica de negocios aquí

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> CrearMatriz(MatrizIpercDTO matriz)
        {
            var nuevaPartida = new Partidas
            {
                IdObra = matriz.IdPartida // Ajustar según la lógica real
            };

            _context.Partidas.Add(nuevaPartida);
            await _context.SaveChangesAsync();
            return nuevaPartida.IdPartida;
        }

        public async Task<bool> EliminarMatriz(int idPartida)
        {
            var partida = await _context.Partidas.FindAsync(idPartida);
            if (partida == null) return false;

            _context.Partidas.Remove(partida);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
