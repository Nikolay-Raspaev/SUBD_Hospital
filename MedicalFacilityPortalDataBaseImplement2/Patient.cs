using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalDataModels.Enums;
using System;
using System.Collections.Generic;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class Patient
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public string? TelephoneNumber { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public static Patient Create(MedDB context, PatientBindingModel model)
    {
        return new Patient()
        {
            Id = model.Id,
            Surname = model.Surname,
            Patronymic = model.Patronymic,
            Name = model.Name,
            Birthdate = model.Birthdate,
            PassportSeries = model.PassportSeries,
            PassportNumber = model.PassportNumber,
        };
    }
    //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой

    public void Update(PatientBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        Surname = model.Surname;
        Patronymic = model.Patronymic;
        Name = model.Name;
        Birthdate = model.Birthdate;
        PassportSeries = model.PassportSeries;
        PassportNumber = model.PassportNumber;
    }

    public PatientViewModel GetViewModel => new()
    {
        Surname = Surname,
        Patronymic = Patronymic,
        Name = Name,
        Birthdate = Birthdate,
        PassportSeries = PassportSeries,
        PassportNumber = PassportNumber,
    };
}
