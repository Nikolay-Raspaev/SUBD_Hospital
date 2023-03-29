using System;
using System.Collections.Generic;

namespace MedDataBaseImplement;

public partial class Doctorsservice
{
    public int DoctorsId { get; set; }

    public int ServicesId { get; set; }

    public virtual List<Contract> Contracts { get; } = new List<Contract>();

    public virtual Doctor Doctors { get; set; } = null!;

    public virtual Service Services { get; set; } = null!;
}
