using MedContracts.BindingModel;
using MedContracts.ViewModels;
using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDataBaseImplement.Models;

public partial class Job : IJob
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual List<Service> Services { get; } = new List<Service>();

    public Dictionary<int, IService> _jobServices { get; set; } = null;

    [NotMapped]
    public Dictionary<int, IService> JobServices
    {
        get
        {
            if (_jobServices == null)
            {
                _jobServices = Services.ToDictionary(recPC => recPC.Id, recPC => (recPC as IService));
            }
            return _jobServices;
        }
    }

    public static Job Create(JobBindingModel model)
    {
        return new Job()
        {
            Id = model.Id,
            JobTitle = model.JobTitle
        };
    }

    public void UpdateComponents(MedBdContext context, JobBindingModel model)
    {
        var jobServices = Services;
        if (jobServices != null && jobServices.Count > 0)
        {   // удалили те в бд, которых нет в модели
            context.Services.RemoveRange(jobServices.Where(rec => !model.DishComponents.ContainsKey(rec.ComponentId)));
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

    //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой

    public void Update(JobBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        JobTitle = model.JobTitle;
    }

    public JobViewModel GetViewModel => new()
    {
        Id = Id,
        JobTitle = JobTitle
    };
}
