using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HospitalBuisnessLogic.BuisnessLogicsContracts;

public interface IExecutionStatusLogic
    {
        List<ExecutionStatusViewModel>? ReadList(ExecutionStatusSearchModel? model);
        ExecutionStatusViewModel? ReadElement(ExecutionStatusSearchModel model);
        bool Create(ExecutionStatusBindingModel model);
        bool Update(ExecutionStatusBindingModel model);
        bool Delete(ExecutionStatusBindingModel model);
    }

