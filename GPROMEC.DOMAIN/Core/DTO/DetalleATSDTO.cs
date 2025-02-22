using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class DetalleATSDto
    {
        // En POST no se envía el Id ya que es autogenerado.
        public int? IdDetalleATS { get; set; }
        public int IdCabeceraATS { get; set; }
        public string? EtapasTrabajo { get; set; }
        public string? Peligros { get; set; }
        public string? RiesgoAmbiental { get; set; }
        public string? MedidaRiesgo { get; set; }
        public int Personal { get; set; }
        // Para firmas, el API hará la conversión; en el DTO se trabaja con base64
        public string? FirmaPersonalBase64 { get; set; }
    }
}
