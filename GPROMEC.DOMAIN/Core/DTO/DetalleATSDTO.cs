using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class DetalleAtsDto : DetalleAtsCreateUpdateDto
    {
        // Este campo se asigna al leer de la BD.
        public int IdDetalleAts { get; set; }

        // Información completa de DetalleIperc (DetallePeligros)
        public DetalleIpercDTO? DetallePeligros { get; set; }
    } 
    

    public class DetalleAtsCreateUpdateDto
    {
        // No se incluye IdDetalleAts ya que es Identity.
        public int IdCabeceraAts { get; set; }
        public string? EtapasTrabajo { get; set; }
        public int IdDetalleIperc { get; set; }
        public int Personal { get; set; }
        // Se recibe la firma en Base64 y se convertirá a byte[] en el Service.
        public string? FirmaPersonalBase64 { get; set; }
    }
}
