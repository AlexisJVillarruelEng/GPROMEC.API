using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class CrearClienteDTO
    {
        public string? NombreCliente { get; set; } // Nombre del cliente.
        public string? ContactoCliente { get; set; } // Persona de contacto.
        public string? CorreoCliente { get; set; } // Correo electrónico.
        public string? TelefonoCliente { get; set; } // Teléfono.
    }

    public class ClienteDTO
    {
        public int IdCliente { get; set; } // ID del cliente.
        public string? NombreCliente { get; set; } // Nombre del cliente.
        public string? ContactoCliente { get; set; } // Persona de contacto.
        public string? CorreoCliente { get; set; } // Correo electrónico.
        public string? TelefonoCliente { get; set; } // Teléfono.
    }
    public class LoginClienteDto
    {
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        // Opcional: Contraseña si la usas en la tabla
    }

}
