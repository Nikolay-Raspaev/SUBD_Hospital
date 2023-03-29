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

    public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

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
    public void UpdateServices(HospitalBdContext context, DishBindingModel model)
    {
        var dishComponents = context.DishComponents.Where(rec => rec.DishId == model.Id).ToList();
        if (dishComponents != null && dishComponents.Count > 0)
        {   // удалили те в бд, которых нет в модели
            context.DishComponents.RemoveRange(dishComponents.Where(rec => !model.DishComponents.ContainsKey(rec.ComponentId)));
            context.SaveChanges();
            // обновили количество у существующих записей
            foreach (var updateComponent in dishComponents)
            {
                updateComponent.Count = model.DishComponents[updateComponent.ComponentId].Item2;
                model.DishComponents.Remove(updateComponent.ComponentId);
            }
            context.SaveChanges();
        }
        var dish = context.Dishes.First(x => x.Id == Id);
        //добавляем в бд блюда которые есть в моделе, но ещё нет в бд
        foreach (var dc in model.DishComponents)
        {
            context.DishComponents.Add(new DishComponent
            {
                Dish = dish,
                Component = context.Components.First(x => x.Id == dc.Key),
                Count = dc.Value.Item2
            });
            context.SaveChanges();
        }
        _dishComponents = null;
    }
}
