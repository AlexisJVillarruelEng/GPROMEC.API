using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class ProcesoDTO
    {
        public int IdProceso { get; set; }
        public string? NombreProceso { get; set; }
        public int? IdPartida { get; set; }
        public string? NombrePartida { get; set; }
    }

    public class CrearProcesoDTO
    {
        public string? NombreProceso { get; set; }
        public int IdPartida { get; set; }
    }

}
