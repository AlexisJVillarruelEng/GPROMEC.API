using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPROMEC.DOMAIN.Core.DTO
{
    /// <summary>
    /// DTO para obtener información de una partida.
    /// </summary>
    public class PartidaDTO
    {
        public int IdPartida { get; set; } // ID de la partida.
        public string? NombrePartida { get; set; } // Nombre de la partida.
        public int IdObra { get; set; } // ID de la obra relacionada.
        public string? NombreObra { get; set; } // Nombre de la obra (relacionada).
    }

    /// <summary>
    /// DTO para crear o actualizar una partida.
    /// </summary>
    public class CrearPartidaDTO
    {
        public string? NombrePartida { get; set; } // Nombre de la partida.
        public int IdObra { get; set; } // ID de la obra relacionada.
    }
}
