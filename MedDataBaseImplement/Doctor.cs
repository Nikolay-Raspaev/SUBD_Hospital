using System;
using System.Collections.Generic;

namespace MedDataBaseImplement;

public partial class Doctor
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public string Passport { get; set; } = null!;

    public string? TelephoneNumber { get; set; }

    public string Education { get; set; } = null!;

    public int JobId { get; set; }

    public int? AcademicRankId { get; set; }

    public virtual Academicrank? AcademicRank { get; set; }

    public virtual List<Doctorsservice> DoctorsServices { get; } = new List<Doctorsservice>();

    public virtual Job Job { get; set; } = null!;
}
