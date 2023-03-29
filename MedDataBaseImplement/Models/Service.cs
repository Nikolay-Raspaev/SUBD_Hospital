using MedContracts.BindingModel;
using MedContracts.ViewModels;
using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace MedDataBaseImplement.Models;

public partial class Service : IService
{
    public int Id { get; set; }

    public string ServicesName { get; set; } = null!;

    public decimal ServicesPrice { get; set; }

    public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

    public virtual List<Job> Jobs { get; } = new List<Job>();

    public static Service Create(ServiceBindingModel model)
    {
        return new Service()
        {
            Id = model.Id,
            ServicesName = model.ServicesName,
            ServicesPrice = model.ServicesPrice
        };
    }
    //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой

    public void Update(ServiceBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        ServicesName = model.ServicesName;
        ServicesPrice = model.ServicesPrice;
    }

    public ServiceViewModel GetViewModel => new()
    {
        ServicesName = ServicesName,
        ServicesPrice = ServicesPrice
    };
}
