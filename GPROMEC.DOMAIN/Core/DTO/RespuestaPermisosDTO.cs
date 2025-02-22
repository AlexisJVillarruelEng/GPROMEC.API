using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class RespuestaPermisosDTO
    {
        public int IdRespuesta { get; set; }
        public int IdForm { get; set; }
        public int IdCabeceraPermisos { get; set; }
        public bool? Respuesta { get; set; }
    }
}
