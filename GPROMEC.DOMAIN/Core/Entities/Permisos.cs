using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Permisos
{
    public int IdPermiso { get; set; }

    public string? TituloPermiso { get; set; }

    public virtual ICollection<CabeceraAts> CabeceraAts { get; set; } = new List<CabeceraAts>();
}
