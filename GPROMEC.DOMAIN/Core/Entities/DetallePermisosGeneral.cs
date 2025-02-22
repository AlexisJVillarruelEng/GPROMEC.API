using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class DetallePermisosGeneral
{
    public int IdDetallePermiso { get; set; }

    public int IdCabeceraPermisos { get; set; }

    public int Trabajador { get; set; }

    public byte[]? FirmaTrabajador { get; set; }

    public virtual CabeceraPermisos IdCabeceraPermisosNavigation { get; set; } = null!;

    public virtual Trabajadores TrabajadorNavigation { get; set; } = null!;
}
