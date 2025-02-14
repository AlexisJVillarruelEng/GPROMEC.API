using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CrearProyectoDTO
    {
        public string? NombreProyecto { get; set; } // Nombre del proyecto.
        public string? Descripcion { get; set; } // Descripción del proyecto.
        public DateOnly? FechaInicio { get; set; } // Fecha de inicio del proyecto.
        public DateOnly? FechaFin { get; set; } // Fecha de finalización del proyecto.
        public int IdCliente { get; set; } // Relación con el cliente.
    }

    public class ProyectoDTO
    {
        public int IdProyecto { get; set; } // ID del proyecto.
        public string? NombreProyecto { get; set; } // Nombre del proyecto.
        public string? Descripcion { get; set; } // Descripción del proyecto.
        public DateOnly? FechaInicio { get; set; } // Fecha de inicio del proyecto.
        public DateOnly? FechaFin { get; set; } // Fecha de finalización del proyecto.
        public bool Estado { get; set; } // Estado del proyecto.
        public string? NombreCliente { get; set; } // Nombre del cliente asociado.
        public int Idcliente { get; set; }
    }

}
