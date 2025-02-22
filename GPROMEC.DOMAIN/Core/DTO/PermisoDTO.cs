using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class PermisoDto
    {
        // En POST, no se envía IdPermiso ya que es autogenerado
        public int? IdPermiso { get; set; }
        public string? TituloPermiso { get; set; }
    }
}
