using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CrearTrabajadorDTO
    {
        public string? Nombre { get; set; } // Nombre del trabajador.
        public string? Apellido { get; set; } // Apellido del trabajador.
        public string? Dni { get; set; } // Documento de identidad.
        public string? Correo { get; set; } // Correo electrónico.
        public string? Contraseña { get; set; } // Contraseña del trabajador.
        public int IdUbigeo { get; set; } // Relación con Ubigeo.
        public int IdRol { get; set; } // Relación con Roles.
    }

    public class InicioSesionDTO
    {
        public string? Correo { get; set; } // Correo del trabajador.
        public string? Contraseña { get; set; } // Contraseña.
    }

    public class TrabajadorDTO
    {
        public int IdTrabajador { get; set; } // ID del trabajador.
        public string? Nombre { get; set; } // Nombre del trabajador.
        public string? Apellido { get; set; } // Apellido del trabajador.
        public string? Correo { get; set; } // Correo del trabajador.
        public string? Contraseña { get; set; }
        public string? Dni { get; set; } // Documento de identidad
        public string? Departamento { get; set; } // Nombre del departamento.
        public string? Rol { get; set; } // Nombre del rol.

        public DateOnly? FechaCreacion { get; set; }
        public bool Estado { get; set; } // Estado del trabajador.
        public int IdUbigeo { get; set; } // Relación con Ubigeo.
        public int IdRol { get; set; } // Relación con Roles.
    }
    public class LoginResponseDTO
    {
        public int IdTrabajador { get; set; } // ID del trabajador.
        public string? Nombre { get; set; } // Nombre del trabajador.
        public string? Rol { get; set; } // Rol del trabajador.
    }
    public class ActualizarTrabajadorDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int IdUbigeo { get; set; }
        public int IdRol { get; set; }
        public bool? Estado { get; set; } // Ahora el estado es opcional
    }
}
