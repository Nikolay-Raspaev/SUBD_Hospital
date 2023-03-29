using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalDataModels.Enums;
using MedicalFacilityPortalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class Doctor
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public string? TelephoneNumber { get; set; }

    public string Education { get; set; } = null!;

    public int JobId { get; set; }

    public AcademicDegree AcademicDegree { get; set; }

    public virtual List<DoctorsServices> DoctorsServices { get;} = new List<DoctorsServices>();

    public virtual Job Job { get; set; } = null!;

    public static Doctor Create(MedDB context, DoctorBindingModel model)
    {
        return new Doctor()
        {
            Id = model.Id,
            Surname = model.Surname,
            Patronymic = model.Patronymic,
            Name = model.Name,
            Birthdate = model.Birthdate,
            PassportSeries = model.PassportSeries,
            PassportNumber = model.PassportNumber,
            Education = model.Education,
            JobId = model.JobId,
            AcademicDegree = model.AcademicDegree,
        };
    }
    //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой

    public void Update(DoctorBindingModel model)
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
        Education = model.Education;
        JobId = model.JobId;
        AcademicDegree = model.AcademicDegree;
    }

    public DoctorViewModel GetViewModel => new()
    {
        Surname = Surname,
        Patronymic = Patronymic,
        Name = Name,
        Birthdate = Birthdate,
        PassportSeries = PassportSeries,
        PassportNumber = PassportNumber,
        Education = Education,
        JobId = JobId,
        AcademicDegree = AcademicDegree
    };
}

