using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class CabeceraAts
{
    public int IdCabeceraats { get; set; }

    public int IdObra { get; set; }

    public int IdPartida { get; set; }

    public int IdTarea { get; set; }

    public bool? EsRutinaria { get; set; }

    public string? Sector { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public bool? RiesgoIdentify { get; set; }

    public bool? EvaluoCondiciones { get; set; }

    public bool? EpAdecuados { get; set; }

    public bool? PersonalCapacitado { get; set; }

    public bool? CordinacionActividades { get; set; }

    public bool? CondicionEquipo { get; set; }

    public bool? RiesgoIncendio { get; set; }

    public bool? TrabajoAltura { get; set; }

    public bool? Andamios { get; set; }

    public bool? TrabajoCaliente { get; set; }

    public bool? ComprometeCondicion { get; set; }

    public int IdPermiso { get; set; }

    public bool? Pilar1 { get; set; }

    public bool? Pilar2 { get; set; }

    public bool? Pilar3 { get; set; }

    public bool? Pilar4 { get; set; }

    public bool? Pilar5 { get; set; }

    public virtual ICollection<CabeceraPermisos> CabeceraPermisos { get; set; } = new List<CabeceraPermisos>();

    public virtual ICollection<DetalleAts> DetalleAts { get; set; } = new List<DetalleAts>();

    public virtual ICollection<FirmasAtsProcesos> FirmasAtsProcesos { get; set; } = new List<FirmasAtsProcesos>();

    public virtual Obras IdObraNavigation { get; set; } = null!;

    public virtual Partidas IdPartidaNavigation { get; set; } = null!;

    public virtual Permisos IdPermisoNavigation { get; set; } = null!;

    public virtual Tareas IdTareaNavigation { get; set; } = null!;
}
