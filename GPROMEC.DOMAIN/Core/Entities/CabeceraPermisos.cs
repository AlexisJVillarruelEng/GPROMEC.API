using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class CabeceraPermisos
{
    public int IdCabeceraPermisos { get; set; }

    public int IdCabeceraAts { get; set; }

    public int IdObra { get; set; }

    public string? Titulo { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public string? ObservacionConsideracion { get; set; }

    public int IdPartida { get; set; }

    public int IdTarea { get; set; }

    public virtual ICollection<DetallePermisosGeneral> DetallePermisosGeneral { get; set; } = new List<DetallePermisosGeneral>();

    public virtual ICollection<FirmasAtsProcesos> FirmasAtsProcesos { get; set; } = new List<FirmasAtsProcesos>();

    public virtual CabeceraAts IdCabeceraAtsNavigation { get; set; } = null!;

    public virtual ICollection<RespuestaPermisos> RespuestaPermisos { get; set; } = new List<RespuestaPermisos>();
}
