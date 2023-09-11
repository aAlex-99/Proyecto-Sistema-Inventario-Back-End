using System;
using System.Collections.Generic;

namespace SistemaInvApi.Models;

public partial class Area
{
    public int IdArea { get; set; }

    public string? NombreArea { get; set; }

    public string? DireccionArea { get; set; }

    public string? Responsable { get; set; }

    public string? NumSucursal { get; set; }

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
