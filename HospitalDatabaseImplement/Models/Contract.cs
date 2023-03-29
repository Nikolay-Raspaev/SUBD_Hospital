using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Contract
{
    public int Id { get; set; }

    public DateOnly? Exercisedate { get; set; }

    public int Executionstatusid { get; set; }

    public int Patientid { get; set; }

    public int Contractdoctorsid { get; set; }

    public int Contractservicesid { get; set; }

    public virtual Doctorsservice ContractNavigation { get; set; } = null!;

    public virtual Executionstatus Executionstatus { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
