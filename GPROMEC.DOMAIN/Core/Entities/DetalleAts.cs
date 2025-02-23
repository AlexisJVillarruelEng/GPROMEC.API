using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class DetalleAts
{
    public int IdDetalleAts { get; set; }

    public int IdCabeceraats { get; set; }

    public string? EtapasTrabajo { get; set; }

    public int IdDetalleiperc { get; set; }

    public int Personal { get; set; }

    public byte[]? FirmaPersonal { get; set; }

    public virtual CabeceraAts IdCabeceraatsNavigation { get; set; } = null!;

    public virtual DetalleIperc IdDetalleipercNavigation { get; set; } = null!;

    public virtual Trabajadores PersonalNavigation { get; set; } = null!;
}
