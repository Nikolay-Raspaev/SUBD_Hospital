using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Academicrank
{
    public int Id { get; set; }

    public string Academicrankname { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
}
