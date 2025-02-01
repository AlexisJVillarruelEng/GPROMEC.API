using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class DetalleIperc
{
    public int IdDetalle { get; set; }

    public int IdTarea { get; set; }

    public string DescPeligros { get; set; } = null!;

    public string? TipoPeligro { get; set; }

    public string? Riesgos { get; set; }

    public string? TipoRiesgo { get; set; }

    public string MedidaControlDescrip { get; set; } = null!;

    public int? PersonasExpuestas { get; set; }

    public int? ProcedimietntosExistentes { get; set; }

    public int? Capacitacion { get; set; }

    public int? ExpoRiesgo { get; set; }

    public int? Probabilidad { get; set; }

    public int? Severidad { get; set; }

    public int? NivielDeRiesgo { get; set; }

    public string? GradoRiesgo { get; set; }

    public virtual Tareas IdTareaNavigation { get; set; } = null!;
}
