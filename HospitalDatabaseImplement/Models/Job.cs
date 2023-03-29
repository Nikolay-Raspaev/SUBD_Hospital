using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Jobtitle { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual ICollection<Servicesjob> Servicesjobs { get; } = new List<Servicesjob>();
}
