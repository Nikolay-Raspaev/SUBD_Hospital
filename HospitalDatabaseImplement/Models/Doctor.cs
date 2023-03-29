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

    public string? TelephoneNumber { get; set; }

    public string Education { get; set; } = null!;

    public int Jobid { get; set; }

    public int? AcademicRankId { get; set; }

    public virtual AcademicRank? Academicrank { get; set; }

    public virtual List<DoctorsService> Doctorsservices { get; } = new List<DoctorsService>();

    public virtual Job Job { get; set; } = null!;
}
