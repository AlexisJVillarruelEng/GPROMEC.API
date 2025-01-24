using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    /// <summary>
    /// DTO para representar la información de una tarea.
    /// </summary>
    public class TareaDTO
    {
        public int IdTarea { get; set; } // Identificador único de la tarea.
        public string? NombreTarea { get; set; } // Nombre descriptivo de la tarea.
        public string? TareaTipo { get; set; } // Tipo de tarea (según la base de datos).
        public int? IdProceso { get; set; } // Relación con el proceso.
        public string? NombreProceso { get; set; } // Nombre del proceso relacionado.
    }

    /// <summary>
    /// DTO para la creación o actualización de tareas.
    /// </summary>
    public class CrearTareaDTO
    {
        public string? NombreTarea { get; set; } // Nombre descriptivo de la tarea.
        public string? TareaTipo { get; set; } // Tipo de tarea (puede ser nulo).
        public int IdProceso { get; set; } // ID del proceso al que pertenece la tarea.
    }

}
