using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class FirmasMatrizIper
{
    public int IdFirma { get; set; }

    public int IdPartida { get; set; }

    public int ElaboradoPor { get; set; }

    public int? RevisadoPor { get; set; }

    public int? AprobadoPor { get; set; }

    public DateTime? FechaElaborado { get; set; }

    public DateTime? FechaRevisado { get; set; }

    public DateTime? FechaAprobado { get; set; }

    public byte[]? FirmaElaboradoUrl { get; set; }

    public byte[]? FirmaRevisadoUrl { get; set; }

    public byte[]? FirmaAprobadoUrl { get; set; }

    public virtual Trabajadores? AprobadoPorNavigation { get; set; }

    public virtual Trabajadores ElaboradoPorNavigation { get; set; } = null!;

    public virtual Partidas IdPartidaNavigation { get; set; } = null!;

    public virtual Trabajadores? RevisadoPorNavigation { get; set; }
}
