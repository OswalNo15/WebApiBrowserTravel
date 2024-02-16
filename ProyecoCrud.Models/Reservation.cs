using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class Reservation
{
    public int IdReservation { get; set; }

    public string? IdClient { get; set; }

    public DateOnly? DateReservation { get; set; }

    public string? State { get; set; }

    public int? IdCar { get; set; }

    public string? IdUser { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? PaymentMode { get; set; }

    public decimal? Amount { get; set; }

    public virtual Car? oCar { get; set; }

    public virtual Client? oClient { get; set; }

    public virtual User? oUser { get; set; }
}
