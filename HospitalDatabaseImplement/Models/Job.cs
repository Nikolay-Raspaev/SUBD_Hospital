using HospitalContracts.BindingModels;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace HospitalDatabaseImplement.Models;

public partial class Job : IJob
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual List<ServicesJob> ServicesJobs { get; set; } = new List<ServicesJob>();

    public Dictionary<int, IService> _jobServices = null;

    [NotMapped]
    public Dictionary<int, IService> JobServices
    {
        get
        {
            if (_jobServices == null)
            {
                _jobServices = ServicesJobs.ToDictionary(recSJ => recSJ.ServicesId, recSJ => recSJ.Services as IService);
            }
            return _jobServices;
        }
    }
    public static Job Create(HospitalBdContext context, JobBindingModel model)
    {
        return new Job()
        {
            Id = model.Id,
            JobTitle = model.JobTitle,
            //ServicesJobs = model.JobServices.Select(x => new ServicesJob
            //{
            //    Id = context.ServicesJobs.Count() > 0 ? context.ServicesJobs.Max(x => x.Id) + 1 : 1,
            //    Services = context.Services.First(y => y.Id == x.Key),
            //}).ToList()
        };
    }

    public void Update(JobBindingModel model)
    {
        JobTitle = model.JobTitle;
    }

    public void UpdateServices(HospitalBdContext context, JobBindingModel model)
    {
        var jobServices = context.ServicesJobs.Where(rec => rec.JobId == model.Id).ToList();
        if (jobServices != null && jobServices.Count > 0)
        {   // удалили те в бд, которых нет в модели
            context.ServicesJobs.RemoveRange(jobServices.Where(rec => !model.JobServices.ContainsKey(rec.ServicesId)));
            context.SaveChanges();
            // обновили количество у существующих записей
            foreach (var updateService in jobServices)
            {
                model.JobServices.Remove(updateService.ServicesId);
            }
            context.SaveChanges();
        }
        var job = context.Jobs.First(x => x.Id == Id);
        //добавляем в бд блюда которые есть в моделе, но ещё нет в бд
        foreach (var dc in model.JobServices)
        {
            context.ServicesJobs.Add(new ServicesJob
            {
                Id = context.ServicesJobs.Count() > 0 ? context.ServicesJobs.Max(x => x.Id) + 1 : 1,
                Job = job,
                Services = context.Services.First(x => x.Id == dc.Key),
            });
            context.SaveChanges();
        }
        _jobServices = null;
    }
    public JobViewModel GetViewModel => new()
    {
        Id = Id,
        JobTitle = JobTitle,
        JobServices = JobServices
    };

}
