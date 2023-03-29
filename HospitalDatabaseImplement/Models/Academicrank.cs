using HospitalDataModels.Models;
using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class AcademicRank : IAcademicRank
{
    public int Id { get; set; }

    public string AcademicRankName { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();
}
