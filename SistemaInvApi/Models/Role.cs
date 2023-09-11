﻿using System;
using System.Collections.Generic;

namespace SistemaInvApi.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
