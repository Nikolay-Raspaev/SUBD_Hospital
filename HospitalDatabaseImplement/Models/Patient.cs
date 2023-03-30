using HospitalContracts.BindingModels;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace HospitalDatabaseImplement.Models;

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

    public static Patient Create(PatientBindingModel model)
    {
        return new Patient()
        {
            Id = model.Id,
            Surname = model.Surname,
            Name = model.Name,
            Patronymic = model.Patronymic,
            Birthdate = model.Birthdate,
            Passport = model.Passport,
            TelephoneNumber = model.TelephoneNumber,
        };
    }

    public void Update(PatientBindingModel model)
    {
        Surname = model.Surname;
        Name = model.Name;
        Patronymic = model.Patronymic;
        Birthdate = model.Birthdate;
        Passport = model.Passport;
        TelephoneNumber = model.TelephoneNumber;
    }
    public PatientViewModel GetViewModel => new()
    {
        Id = Id,
        Surname = Surname,
        Name = Name,
        Patronymic = Patronymic,
        Birthdate = Birthdate,
        Passport = Passport,
        TelephoneNumber = TelephoneNumber,
    };
}
