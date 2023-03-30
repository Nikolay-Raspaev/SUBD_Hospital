using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class DoctorsService
{
    public int DoctorsId { get; set; }

    public int ServicesId { get; set; }

    public virtual List<Contract> Contracts { get; } = new List<Contract>();

    public virtual Doctor Doctors { get; set; } = null!;

    public virtual Service Services { get; set; } = null!;

    public DoctorServiceViewModel GetViewModel => new()
    {
        DoctorsId = DoctorsId,
        ServicesId = ServicesId,
        DoctorName = Doctors.Name,
        ServiceName = Services.ServiceName,
    };
}
