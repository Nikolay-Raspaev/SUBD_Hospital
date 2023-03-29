using System;
using System.Collections.Generic;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class DoctorsServices
{
    public int Id { get; set; }

    public int DoctorsId { get; set; }

    public int ServicesId { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public virtual Doctor Doctors { get; set; } = null!;

    public virtual Service Services { get; set; } = null!;
}
