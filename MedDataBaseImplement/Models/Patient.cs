using MedDataModels.Models;
using System;
using System.Collections.Generic;

namespace MedDataBaseImplement.Models;

public partial class Patient : IPatient
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string Passport { get; set; } = null!;

    public string? TelephoneNumber { get; set; }

    public virtual List<Contract> Contracts { get; } = new List<Contract>();
}
