using System;
using System.Collections.Generic;

namespace SistemaInvApi.Models;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public string? Nombre { get; set; }

    public int? IdArea { get; set; }

    public int? IdRol { get; set; }

    public int? Extencion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
