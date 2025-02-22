using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class RespuestaPermisos
{
    public int IdRespuesta { get; set; }

    public int IdForm { get; set; }

    public int IdCabeceraPermisos { get; set; }

    public bool? Respuesta { get; set; }

    public virtual CabeceraPermisos IdCabeceraPermisosNavigation { get; set; } = null!;

    public virtual FormPermisos IdFormNavigation { get; set; } = null!;
}
