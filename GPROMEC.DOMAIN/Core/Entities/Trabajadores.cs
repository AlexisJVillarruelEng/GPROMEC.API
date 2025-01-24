using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Trabajadores
{
    public int IdTrabajador { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Dni { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public int IdUbigeo { get; set; }

    public int IdRol { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<FirmasMatrizIper> FirmasMatrizIperAprobadoPorNavigation { get; set; } = new List<FirmasMatrizIper>();

    public virtual ICollection<FirmasMatrizIper> FirmasMatrizIperElaboradoPorNavigation { get; set; } = new List<FirmasMatrizIper>();

    public virtual ICollection<FirmasMatrizIper> FirmasMatrizIperRevisadoPorNavigation { get; set; } = new List<FirmasMatrizIper>();

    public virtual Roles IdRolNavigation { get; set; } = null!;

    public virtual Ubigeo IdUbigeoNavigation { get; set; } = null!;
}
