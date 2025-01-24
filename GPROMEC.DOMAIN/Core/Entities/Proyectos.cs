using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Proyectos
{
    public int IdProyecto { get; set; }

    public int? IdCliente { get; set; }

    public string? NombreProyecto { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<ArchivosGenerados> ArchivosGenerados { get; set; } = new List<ArchivosGenerados>();

    public virtual Clientes? IdClienteNavigation { get; set; }

    public virtual ICollection<Obras> Obras { get; set; } = new List<Obras>();
}
