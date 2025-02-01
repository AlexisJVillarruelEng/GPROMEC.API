using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CrearFirmaDTO
    {
        public int IdPartida { get; set; } // ID del detalle relacionado.
        public int ElaboradoPor { get; set; } // ID del trabajador que elabora.
        public int RevisadoPor { get; set; } // ID del trabajador que revisa.
        public int AprobadoPor { get; set; } // ID del trabajador que aprueba.
        public string? FirmaElaboradoBase64 { get; set; } // Firma elaborada en Base64.
        public string? FirmaRevisadoBase64 { get; set; } // Firma revisada en Base64.
        public string? FirmaAprobadoBase64 { get; set; } // Firma aprobada en Base64.
    }

    public class ActualizarFirmaDTO
    {
        public int ElaboradoPor { get; set; } // ID del trabajador que actualiza "Elaborado por".
        public int RevisadoPor { get; set; } // ID del trabajador que actualiza "Revisado por".
        public int AprobadoPor { get; set; } // ID del trabajador que actualiza "Aprobado por".
        public string? FirmaElaboradoBase64 { get; set; } // Firma elaborada en Base64.
        public string? FirmaRevisadoBase64 { get; set; } // Firma revisada en Base64.
        public string? FirmaAprobadoBase64 { get; set; } // Firma aprobada en Base64.
    }

    public class FirmasDTO
    {
        public int IdFirma { get; set; }
        public int IdPartida { get; set; }
        public string? NombreElaboradoPor { get; set; }
        public string? NombreRevisadoPor { get; set; }
        public string? NombreAprobadoPor { get; set; }
        public DateTime? FechaElaborado { get; set; }
        public DateTime? FechaRevisado { get; set; }
        public DateTime? FechaAprobado { get; set; }
        public byte[]? FirmaElaboradoUrl { get; set; }
        public byte[]? FirmaRevisadoUrl { get; set; }
        public byte[]? FirmaAprobadoUrl { get; set; }
    }
}
