using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string Passport { get; set; } = null!;

    public string? Telephonenumber { get; set; }

    public string Education { get; set; } = null!;

    public int Jobid { get; set; }

    public int? Academicrankid { get; set; }

    public virtual Academicrank? Academicrank { get; set; }

    public virtual ICollection<Doctorsservice> Doctorsservices { get; } = new List<Doctorsservice>();

    public virtual Job Job { get; set; } = null!;
}
