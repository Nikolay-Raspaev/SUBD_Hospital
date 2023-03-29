using HospitalContracts.BindingModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
            ServicesJobs = model.JobServices.Select(x => new ServicesJob
            {
                Services = context.Services.First(y => y.Id == x.Key),
            }).ToList()
        };
    }

}
