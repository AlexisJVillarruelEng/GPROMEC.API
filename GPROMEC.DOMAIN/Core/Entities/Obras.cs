using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Obras
{
    public int IdObra { get; set; }

    public int IdProyecto { get; set; }

    public string? NombreObra { get; set; }

    public string? Ubicacion { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public virtual Proyectos IdProyectoNavigation { get; set; } = null!;

    public virtual ICollection<Partidas> Partidas { get; set; } = new List<Partidas>();
}
