using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CabeceraATSDto
    {
        // No se envía el ID en POST, ya que es Identity.
        public int? IdCabeceraATS { get; set; }
        public int IdObra { get; set; }
        public int IdPartida { get; set; }
        public int IdTarea { get; set; }
        public bool EsRutinaria { get; set; }
        public string? Sector { get; set; }
        public DateOnly? Fecha { get; set; }
        public TimeOnly? Hora { get; set; }
        public bool RiesgoIdentify { get; set; }
        public bool EvaluoCondiciones { get; set; }
        public bool EpAdecuados { get; set; }
        public bool PersonalCapacitado { get; set; }
        public bool CordinacionActividades { get; set; }
        public bool CondicionEquipo { get; set; }
        public bool RiesgoIncendio { get; set; }
        public bool TrabajoAltura { get; set; }
        public bool Andamios { get; set; }
        public bool TrabajoCaliente { get; set; }
        public bool ComprometeCondicion { get; set; }
        public int IdPermiso { get; set; }
        public bool Pilar1 { get; set; }
        public bool Pilar2 { get; set; }
        public bool Pilar3 { get; set; }
        public bool Pilar4 { get; set; }
        public bool Pilar5 { get; set; }
    }
}
