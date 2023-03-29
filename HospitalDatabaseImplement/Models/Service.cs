using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Service
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal ServicePrice { get; set; }

    public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

    public virtual List<ServicesJob> ServicesJobs { get; } = new List<ServicesJob>();
}
