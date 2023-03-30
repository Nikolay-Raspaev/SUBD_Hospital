using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.BuisnessLogicsContracts;

public interface IServiceLogic
    {
        List<ServiceViewModel>? ReadList(ServiceSearchModel? model);
        ServiceViewModel? ReadElement(ServiceSearchModel model);
        bool Create(ServiceBindingModel model);
        bool Update(ServiceBindingModel model);
        bool Delete(ServiceBindingModel model);
    }

