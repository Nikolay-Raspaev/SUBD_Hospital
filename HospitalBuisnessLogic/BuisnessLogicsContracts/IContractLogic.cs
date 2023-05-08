using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogicsContracts;

public interface IContractLogic
    {
        List<ContractViewModel>? ReadList(ContractSearchModel? model);
        List<Contract>? ReadListContract(ContractSearchModel? model);
        ContractViewModel? ReadElement(ContractSearchModel model);
        bool Create(ContractBindingModel model);
        bool Update(ContractBindingModel model);
        bool Delete(ContractBindingModel model);
    }