using MedDataModels.Models;
using System;
using System.Collections.Generic;

namespace MedDataBaseImplement.Models;

public partial class Doctor : IDoctor
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

    public virtual AcademicRank? AcademicRank { get; set; }

    public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

    public virtual Job Job { get; set; } = null!;
}
