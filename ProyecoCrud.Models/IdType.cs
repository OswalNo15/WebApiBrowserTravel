using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class IdType
{
    public int IdIdtype { get; set; }

    public string? NameIdType { get; set; }

    public virtual ICollection<Client> ICClients { get; set; } = new List<Client>();
}
