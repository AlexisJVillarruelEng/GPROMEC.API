using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class ArchivosGenerados
{
    public int IdArchivo { get; set; }

    public int? IdRelacion { get; set; }

    public string? TablaRelacion { get; set; }

    public string? TipoArchivo { get; set; }

    public string? NombreArchivo { get; set; }

    public string? UrlArchivo { get; set; }

    public DateTime? FechaGeneracion { get; set; }

    public bool? Estado { get; set; }

    public string? GeneradoPor { get; set; }

    public virtual Proyectos? IdRelacionNavigation { get; set; }
}
