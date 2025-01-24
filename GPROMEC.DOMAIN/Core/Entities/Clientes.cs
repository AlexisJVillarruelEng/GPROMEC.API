using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Clientes
{
    public int IdCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? ContactoCliente { get; set; }

    public string? CorreoCliente { get; set; }

    public string? TelefonoCliente { get; set; }

    public virtual ICollection<Proyectos> Proyectos { get; set; } = new List<Proyectos>();
}
