using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class FirmasMatrizIper
{
    public int IdFirma { get; set; }

    public int IdDetalle { get; set; }

    public int ElaboradoPor { get; set; }

    public int? RevisadoPor { get; set; }

    public int? AprobadoPor { get; set; }

    public DateTime? FechaElaborado { get; set; }

    public DateTime? FechaRevisado { get; set; }

    public DateTime? FechaAprobado { get; set; }

    public string? FirmaElaboradoUrl { get; set; }

    public string? FirmaRevisadoUrl { get; set; }

    public string? FirmaAprobadoUrl { get; set; }

    public virtual Trabajadores? AprobadoPorNavigation { get; set; }

    public virtual Trabajadores ElaboradoPorNavigation { get; set; } = null!;

    public virtual DetalleIperc IdDetalleNavigation { get; set; } = null!;

    public virtual Trabajadores? RevisadoPorNavigation { get; set; }
}
