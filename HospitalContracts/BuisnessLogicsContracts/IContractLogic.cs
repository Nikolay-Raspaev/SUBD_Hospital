using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.BuisnessLogicsContracts;

public interface IContractLogic
    {
        List<ContractViewModel>? ReadList(ContractSearchModel? model);
        ContractViewModel? ReadElement(ContractSearchModel model);
        bool Create(ContractBindingModel model);
        bool Update(ContractBindingModel model);
        bool Delete(ContractBindingModel model);
    }

