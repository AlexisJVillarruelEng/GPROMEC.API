using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class FormPermisos
{
    public int IdForm { get; set; }

    public string TituloPermiso { get; set; } = null!;

    public string? DescripPreguntas { get; set; }

    public virtual ICollection<RespuestaPermisos> RespuestaPermisos { get; set; } = new List<RespuestaPermisos>();
}
