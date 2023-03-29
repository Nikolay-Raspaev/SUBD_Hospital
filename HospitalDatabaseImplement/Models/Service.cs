using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Service
{
    public int Id { get; set; }

    public string ServicesName { get; set; } = null!;

    public decimal ServicesPrice { get; set; }

    public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

    public virtual List<ServicesJob> ServicesJobs { get; } = new List<ServicesJob>();
}
