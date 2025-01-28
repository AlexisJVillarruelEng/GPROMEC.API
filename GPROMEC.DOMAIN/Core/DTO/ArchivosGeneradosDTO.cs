using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GPROMEC.DOMAIN.Core.DTO
{
    public class ArchivoGeneradoCrearDto
    {
        public int IdRelacion { get; set; } // Relación con un proyecto u otra entidad
        public string? TablaRelacion { get; set; } // Nombre de la tabla relacionada
        public string? Carpeta { get; set; } // Nombre de la carpeta
        public string? NombreArchivo { get; set; } // Nombre del archivo
        public string? GeneradoPor { get; set; }
        public byte[]? Archivo { get; set; } // Archivo como arreglo de bytes
    }

    public class ArchivoGeneradoDto
    {
        public int IdArchivo { get; set; } // ID único del archivo
        public int IdRelacion { get; set; } // Relación con un proyecto u otra entidad
        public string? TablaRelacion { get; set; } // Nombre de la tabla relacionada
        public string? Carpeta { get; set; } // Nombre de la carpeta
        public string? NombreArchivo { get; set; } // Nombre del archivo
        public DateTime FechaGeneracion { get; set; } // Fecha y hora de creación del archivo
        public string? GeneradoPor { get; set; } // Usuario que generó el archivo
        public bool Estado { get; set; } // Estado lógico del archivo
        public byte[]? Archivo { get; set; } // Archivo como arreglo de bytes
    }


}
