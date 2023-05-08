using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HospitalDatabaseImplement.StoragesContracts;

public interface IExecutionStatusStorage
{
    List<ExecutionStatusViewModel> GetFullList();
    List<ExecutionStatusViewModel> GetFilteredList(ExecutionStatusSearchModel model);
    ExecutionStatusViewModel? GetElement(ExecutionStatusSearchModel model);
    ExecutionStatusViewModel? Insert(ExecutionStatusBindingModel model);
    ExecutionStatusViewModel? Update(ExecutionStatusBindingModel model);
    ExecutionStatusViewModel? Delete(ExecutionStatusBindingModel model);
}

