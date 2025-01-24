using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Procesos
{
    public int IdProceso { get; set; }

    public int? IdPartida { get; set; }

    public string? NombreProceso { get; set; }

    public virtual Partidas? IdPartidaNavigation { get; set; }

    public virtual ICollection<Tareas> Tareas { get; set; } = new List<Tareas>();
}
