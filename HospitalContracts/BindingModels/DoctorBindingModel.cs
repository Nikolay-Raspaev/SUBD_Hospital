using HospitalDataModels.Models;
using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class DoctorBindingModel : IDoctor
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

    public Dictionary<int, IService> DoctorServices { get; set; } = new();
}
