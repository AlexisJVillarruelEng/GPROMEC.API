using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Tareas
{
    public int IdTarea { get; set; }

    public int? IdProceso { get; set; }

    public string? NombreTarea { get; set; }

    public string? TareaTipo { get; set; }

    public virtual ICollection<CabeceraAts> CabeceraAts { get; set; } = new List<CabeceraAts>();

    public virtual ICollection<DetalleIperc> DetalleIperc { get; set; } = new List<DetalleIperc>();

    public virtual Procesos? IdProcesoNavigation { get; set; }
}
