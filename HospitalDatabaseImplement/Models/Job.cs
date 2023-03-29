using HospitalDataModels.Models;
using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Job : IJob
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual List<ServicesJob> ServicesJobs { get; } = new List<ServicesJob>();

    public Dictionary<int, IService> JobServices { get; set; } = new();
}
