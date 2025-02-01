using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class MatrizIpercDTO
    {
        public int IdPartida { get; set; }
        public List<ProcesosDTO> Procesos { get; set; } = new List<ProcesosDTO>();
        public FirmaDTO Firmas { get; set; }
    }
    public class ProcesosDTO
    {
        public int IdProceso { get; set; }
        public string NombreProceso { get; set; }
        public List<TareasDTO> Tareas { get; set; } = new List<TareasDTO>();
    }
    public class TareasDTO
    {
        public int IdTarea { get; set; }
        public string NombreTarea { get; set; }
        public List<DetallesIpercDTO> DetallesIperc { get; set; } = new List<DetallesIpercDTO>();
    }
    public class DetallesIpercDTO
    {
        public int IdDetalle { get; set; }
        public string DescPeligros { get; set; }
        public string TipoPeligro { get; set; }
        public string Riesgos { get; set; }
        public string TipoRiesgo { get; set; }
        public string? MedidaControlDescrip { get; set; }
        public int PersonasExpuestas { get; set; }
        public int ProcedimientosExistentes { get; set; }

        public int Capacitacion { get; set; }

        public int ExpoRiesgo { get; set; }

        public int Probabilidad { get; set; }
        public int Severidad { get; set; }
        public int NivielDeRiesgo { get; set; }
        public string GradoRiesgo { get; set; }
    }
    public class FirmaDTO
    {
        public int IdFirma { get; set; }
        public int IdPartida { get; set; }
        public int ElaboradoPor { get; set; }
        public int RevisadoPor { get; set; }
        public int AprobadoPor { get; set; }
        public DateTime? FechaElaborado { get; set; }
        public DateTime? FechaRevisado { get; set; }
        public DateTime? FechaAprobado { get; set; }

        // Firmas en Base64
        public byte[]? FirmaElaboradoBase64 { get; set; }
        public byte[]? FirmaRevisadoBase64 { get; set; }
        public byte[]? FirmaAprobadoBase64 { get; set; }
    }



}
