using HospitalContracts.BindingModels;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HospitalDatabaseImplement.Models;

public partial class Service : IService
{
    public int Id { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal ServicePrice { get; set; }

    public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

    public virtual List<ServicesJob> ServicesJobs { get; } = new List<ServicesJob>();

    public static Service? Create(ServiceBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return new Service()
        {
            Id = model.Id,
            ServiceName = model.ServiceName,
            ServicePrice = model.ServicePrice
        };
    }

    public void Update(ServiceBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        ServiceName = model.ServiceName;
        ServicePrice = model.ServicePrice;
    }

    public ServiceViewModel GetViewModel => new()
    {
        Id = Id,
        ServiceName = ServiceName,
        ServicePrice = ServicePrice
    };
}
