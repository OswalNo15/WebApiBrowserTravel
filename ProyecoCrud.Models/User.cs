using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class User
{
    public string IdUser { get; set; } = null!;

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public int? IdRole { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Passwordhash { get; set; }

    public virtual Role? oRole { get; set; }

    public virtual ICollection<Reservation> ICReservations { get; set; } = new List<Reservation>();
}
