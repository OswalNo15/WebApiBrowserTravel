using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class Car
{
    public int IdCar { get; set; }

    public string? Brand { get; set; }

    public int? Model { get; set; }

    public string? Color { get; set; }

    public string? Tuition { get; set; }

    public long? Milleage { get; set; }

    public bool? Asset { get; set; }
    public string? Locality_collected { get; set; }
    public string? Return_location { get; set; }
    public bool? Available { get; set; }

    public virtual ICollection<Reservation> OReservations { get; set; } = new List<Reservation>();
}
