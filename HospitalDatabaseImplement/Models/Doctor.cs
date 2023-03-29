using HospitalContracts.BindingModels;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace HospitalDatabaseImplement.Models;

public partial class Doctor : IDoctor
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

    public virtual AcademicRank AcademicRank { get; set; }

    public virtual List<DoctorsService> DoctorsServices { get; set; } = new List<DoctorsService>();

    public virtual Job Job { get; set; }

    public Dictionary<int, IService> _doctorServices = null;

    [NotMapped]
    public Dictionary<int, IService> DoctorServices
    {
        get
        {
            if (_doctorServices == null)
            {
                _doctorServices = DoctorsServices.ToDictionary(recDS => recDS.ServicesId, recDS => recDS.Services as IService);
            }
            return _doctorServices;
        }
    }

    public static Doctor Create(HospitalBdContext context, DoctorBindingModel model)
    {
        return new Doctor()
        {
            Id = model.Id,
            Surname = model.Surname,
            Name = model.Name,
            Patronymic = model.Patronymic,
            Birthdate = model.Birthdate,
            Passport = model.Passport,
            TelephoneNumber = model.TelephoneNumber,
            Education = model.Education,
            Jobid = model.Jobid,
            AcademicRankId = model.AcademicRankId,
            DoctorsServices = model.DoctorServices.Select(x => new DoctorsService
            {
                Services = context.Services.First(y => y.Id == x.Key),
            }).ToList()
        };
    }

    public void Update(DoctorBindingModel model)
    {
        Surname = model.Surname;
        Name = model.Name;
        Patronymic = model.Patronymic;
        Birthdate = model.Birthdate;
        Passport = model.Passport;
        TelephoneNumber = model.TelephoneNumber;
        Jobid = model.Jobid;
        AcademicRankId = model.AcademicRankId;
    }
    public DoctorViewModel GetViewModel => new()
    {
        Id = Id,
        Surname = Surname,
        Name = Name,
        Patronymic = Patronymic,
        Birthdate = Birthdate,
        Passport = Passport,
        TelephoneNumber = TelephoneNumber,
        JobTitle = Job.JobTitle,
        AcademicRankName = AcademicRank.AcademicRankName
    };
    public void UpdateServices(HospitalBdContext context, DoctorBindingModel model)
    {
        var doctorServices = context.DoctorsServices.Where(rec => rec.DoctorsId == model.Id).ToList();
        if (doctorServices != null && doctorServices.Count > 0)
        {   // удалили те в бд, которых нет в модели
            context.DoctorsServices.RemoveRange(doctorServices.Where(rec => !model.DoctorServices.ContainsKey(rec.ServicesId)));
            context.SaveChanges();
            // обновили количество у существующих записей
            foreach (var updateServices in doctorServices)
            {
                model.DoctorServices.Remove(updateServices.ServicesId);
            }
            context.SaveChanges();
        }
        var doctor = context.Doctors.First(x => x.Id == Id);
        //добавляем в бд блюда которые есть в моделе, но ещё нет в бд
        foreach (var ds in model.DoctorServices)
        {
            context.DoctorsServices.Add(new DoctorsService
            {
                Doctors = doctor,
                Services = context.Services.First(x => x.Id == ds.Key),
            });
            context.SaveChanges();
        }
        _doctorServices = null;
    }
}
