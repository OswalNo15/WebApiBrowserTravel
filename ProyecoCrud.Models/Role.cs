using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<User> ICUser { get; set; } = new List<User>();
}
