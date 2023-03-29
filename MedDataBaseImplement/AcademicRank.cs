using System;
using System.Collections.Generic;

namespace MedDataBaseImplement;

public partial class Academicrank
{
    public int Id { get; set; }

    public string AcademicRankName { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
}
