using MedContracts.BindingModel;
using MedContracts.SearchModels;
using MedContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.StoragesContracts
{
    public interface IServiceStorage
    {
        List<ServiceViewModel> GetFullList();
        List<ServiceViewModel> GetFilteredList(ServiceSearchModel model);
        ServiceViewModel? GetElement(ServiceSearchModel model);
        ServiceViewModel? Insert(ServiceBindingModel model);
        ServiceViewModel? Update(ServiceBindingModel model);
        ServiceViewModel? Delete(ServiceBindingModel model);
    }
}
