using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CrearDetalleIpercDTO
    {
        public int IdTarea { get; set; } // Relación con la tarea
        public string? DescPeligros { get; set; } // Descripción de peligros
        public string? TipoPeligro { get; set; } // Tipo de peligro
        public string? Riesgos { get; set; } // Riesgos identificados
        public string? TipoRiesgo { get; set; } // Tipo de riesgo
        public string? MedidaControlDescrip { get; set; } // Medidas de control existentes
        public int PersonasExpuestas { get; set; } // Personas expuestas
        public int ProcedimientosExistentes { get; set; } // Procedimientos existentes
        public int Capacitacion { get; set; } // Nivel de capacitación
        public int ExpoRiesgo { get; set; } // Exposición al riesgo
        public int Severidad { get; set; } // Severidad
    }

    public class DetalleIpercDTO
    {
        public int IdDetalle { get; set; } // ID del detalle
        public int IdTarea { get; set; } // Relación con la tarea
        public string? DescPeligros { get; set; }
        public string? TipoPeligro { get; set; }
        public string? Riesgos { get; set; }
        public string? TipoRiesgo { get; set; }
        public string? MedidaControlDescrip { get; set; }
        public int PersonasExpuestas { get; set; }
        public int ProcedimientosExistentes { get; set; }
        public int Capacitacion { get; set; }
        public int ExpoRiesgo { get; set; }
        public int Probabilidad { get; set; } // Calculado en el servicio
        public int Severidad { get; set; }
        public int NivelDeRiesgo { get; set; } // Calculado en el servicio
        public string? GradoDeRiesgo { get; set; } // Calculado en el servicio
    }


}
