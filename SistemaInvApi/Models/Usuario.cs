using System;
using System.Collections.Generic;

namespace SistemaInvApi.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public int? IdRol { get; set; }

    public int? IdArea { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
