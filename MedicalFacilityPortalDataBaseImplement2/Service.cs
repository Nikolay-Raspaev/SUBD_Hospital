using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual List<DoctorsServices> DoctorsServices { get; } = new List<DoctorsServices>();

    public virtual List<Servicesjob> Servicesjobs { get; } = new List<Servicesjob>();

    public static Service Create(ServiceBindingModel model)
    {
        return new Service()
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price
        };
    }
    //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой

    public void Update(ServiceBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        Name = model.Name;
        Price = model.Price;
    }

    public ServiceViewModel GetViewModel => new()
    {
        Name = Name,
        Price = Price
    };
}
