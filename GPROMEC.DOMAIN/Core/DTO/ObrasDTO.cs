using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CrearObraDTO
    {
        public int IdProyecto { get; set; } // Relación con la tabla Proyectos.
        public string? NombreObra { get; set; } // Nombre de la obra.
        public string? Ubicacion { get; set; } // Ubicación de la obra.
        public DateOnly? FechaInicio { get; set; } // Fecha de inicio.
        public DateOnly? FechaFin { get; set; } // Fecha de fin.
    }

    public class ObraDTO
    {
        public int IdObra { get; set; } // Identificador único.
        public string? NombreObra { get; set; } // Nombre de la obra.
        public string? Ubicacion { get; set; } // Ubicación.
        public DateOnly? FechaInicio { get; set; } // Fecha de inicio.
        public DateOnly? FechaFin { get; set; } // Fecha de fin.
        public string? NombreProyecto { get; set; } // Nombre del proyecto relacionado.
    }
}
