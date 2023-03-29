using MedDataModels.Models;
using System;
using System.Collections.Generic;

namespace MedDataBaseImplement.Models;

public partial class Job : IJob
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual List<Service> Services { get; } = new List<Service>();
}
