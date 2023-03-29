using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class AcademicRank
{
    public int Id { get; set; }

    public string AcademicRankName { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
}
