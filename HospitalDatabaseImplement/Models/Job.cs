using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Job
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual List<ServicesJob> ServicesJobs { get; } = new List<ServicesJob>();
}
