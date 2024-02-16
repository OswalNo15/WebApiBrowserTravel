using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class Client
{
    public string IdClient { get; set; } = null!;

    public string? FirstNameClient { get; set; }

    public string? SecondNameClient { get; set; }

    public string? FirstSurnameClient { get; set; }

    public string? SecondSurnameClient { get; set; }

    public string? GenderClient { get; set; }

    public DateOnly? BirthdateClient { get; set; }

    public int? AgeClient { get; set; }

    public string? PhoneClient { get; set; }

    public string? AddressClient { get; set; }

    public int? TypeidId { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Reservation> ICReservations { get; set; } = new List<Reservation>();

    public virtual IdType? oIdType { get; set; }
}
