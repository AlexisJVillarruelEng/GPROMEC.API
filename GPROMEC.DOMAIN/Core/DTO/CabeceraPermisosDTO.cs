using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CabeceraPermisosDTO
    {
        public int IdCabeceraPermisos { get; set; }
        public int IdCabeceraAts { get; set; }
        public int IdObra { get; set; }
        public string? Titulo { get; set; }

        // Se actualiza: Usamos DateTime en lugar de string
        public DateOnly Fecha { get; set; }

        public TimeOnly? HoraInicio { get; set; }
        public TimeOnly? HoraFin { get; set; }
        public string? ObservacionConsideracion { get; set; }
        public int IdPartida { get; set; }
        public int IdTarea { get; set; }
    }
}
