using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.StoragesContracts;

public interface IContractStorage
{
    List<ContractViewModel> GetFullList();
    List<Contract> GetFullListContract();
    ContractViewModel? GetElement(ContractSearchModel model);
    ContractViewModel? Insert(ContractBindingModel model);
    ContractViewModel? Update(ContractBindingModel model);
    ContractViewModel? Delete(ContractBindingModel model);
}

