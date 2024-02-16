using System;
using System.Collections.Generic;

namespace ProyectoCrud.Models;

public partial class PreferenceClient
{
    public int IdPreferenceType { get; set; }

    public string IdClient { get; set; } = null!;

    public virtual Client oClient { get; set; } = null!;

    public virtual Preference oPreference { get; set; } = null!;
}
