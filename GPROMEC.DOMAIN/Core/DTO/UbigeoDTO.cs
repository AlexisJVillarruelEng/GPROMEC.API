using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class UbigeoDTO
    {

        public int IdUbigeo { get; set; }
        public string? Departamento { get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }

    }
    public class CrearUbigeoDTO
    {
        public string? Departamento { get; set; } // Nombre del departamento
        public string? Provincia { get; set; }    // Nombre de la provincia
        public string? Distrito { get; set; }     // Nombre del distrito
    }
}
    