using MedContracts.BindingModel;
using MedContracts.SearchModels;
using MedContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.BuisnessLogics
{
    public interface IServiceLogic
    {
        List<ServiceViewModel>? ReadList(ServiceSearchModel? model);
        ServiceViewModel? ReadElement(ServiceSearchModel model);
        bool Create(ServiceBindingModel model);
        bool Update(ServiceBindingModel model);
        //удаляем если не с чем не связана
        bool Delete(ServiceBindingModel model);
    }
}
