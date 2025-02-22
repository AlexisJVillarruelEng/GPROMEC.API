using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class DetallePermisoGeneral
    {
        public int IdDetalle { get; set; }
        public int IdCabeceraPermisos { get; set; }
        public int Trabajador { get; set; }
        public string? FirmaTrabajadorBase64 { get; set; }
    }
}
