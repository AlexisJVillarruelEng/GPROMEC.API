using System;
using System.Collections.Generic;

namespace GPROMEC.DOMAIN.Core.Entities;

public partial class Partidas
{
    public int IdPartida { get; set; }

    public int IdObra { get; set; }

    public string? NombrePartida { get; set; }

    public virtual ICollection<FirmasMatrizIper> FirmasMatrizIper { get; set; } = new List<FirmasMatrizIper>();

    public virtual Obras IdObraNavigation { get; set; } = null!;

    public virtual ICollection<Procesos> Procesos { get; set; } = new List<Procesos>();
}
