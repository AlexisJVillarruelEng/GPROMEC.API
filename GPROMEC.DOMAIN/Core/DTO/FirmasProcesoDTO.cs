using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class FirmasAtsProcesosDto
    {
        // En POST no se envía el Id (Identity)
        public int? IdFirmas { get; set; }
        public int IdCabeceraPermisos { get; set; }
        public int IdCabeceraAts { get; set; }
        public int Elaborado { get; set; }
        public int Aprobado { get; set; }
        public int Revisado { get; set; }
        // En el DTO se usan strings para las firmas (base64)
        public string? FirmaElaboradoBase64 { get; set; }
        public string? FirmaRevisadoBase64 { get; set; }
        public string? FirmaAprobadoBase64 { get; set; }
    }
}
