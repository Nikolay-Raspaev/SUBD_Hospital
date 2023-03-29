using System;
using System.Collections.Generic;

namespace MedDataBaseImplement;

public partial class Job
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual List<Service> Services { get; } = new List<Service>();
}
