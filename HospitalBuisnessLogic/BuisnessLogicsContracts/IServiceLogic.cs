using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogicsContracts;

public interface IServiceLogic
    {
        List<ServiceViewModel>? ReadList(int id);
        ServiceViewModel? ReadElement(ServiceSearchModel model);
        bool Create(ServiceBindingModel model);
        bool Update(ServiceBindingModel model);
        bool Delete(ServiceBindingModel model);
    }

