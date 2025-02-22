using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class FirmasAtsProcesos
{
    public int IdFirmas { get; set; }

    public int IdCabeceraAts { get; set; }

    public int IdCabeceraPermisos { get; set; }

    public int Elaborado { get; set; }

    public int Aprobado { get; set; }

    public int Revisado { get; set; }

    public byte[]? FirmaElaborado { get; set; }

    public byte[]? FirmaRevisado { get; set; }

    public byte[]? FirmaAprobado { get; set; }

    public virtual Trabajadores AprobadoNavigation { get; set; } = null!;

    public virtual Trabajadores ElaboradoNavigation { get; set; } = null!;

    public virtual CabeceraAts IdCabeceraAtsNavigation { get; set; } = null!;

    public virtual CabeceraPermisos IdCabeceraPermisosNavigation { get; set; } = null!;

    public virtual Trabajadores RevisadoNavigation { get; set; } = null!;
}
