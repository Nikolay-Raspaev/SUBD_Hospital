using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement;

public partial class Doctorsservice
{
    public int Doctorsid { get; set; }

    public int Servicesid { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public virtual Doctor Doctors { get; set; } = null!;

    public virtual Service Services { get; set; } = null!;
}
