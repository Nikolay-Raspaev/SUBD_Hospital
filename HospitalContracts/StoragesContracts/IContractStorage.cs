using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.StoragesContracts;

public interface IContractStorage
{
    List<ContractViewModel> GetFullList();
    ContractViewModel? GetElement(ContractSearchModel model);
    ContractViewModel? Insert(ContractBindingModel model);
    ContractViewModel? Update(ContractBindingModel model);
    ContractViewModel? Delete(ContractBindingModel model);
}

