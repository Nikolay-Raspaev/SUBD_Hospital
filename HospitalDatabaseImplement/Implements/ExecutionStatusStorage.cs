using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.Implements
{
    public class ExecutionStatusStorage : IExecutionStatusStorage
    {
        public ExecutionStatusViewModel? Delete(ExecutionStatusBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ExecutionStatusViewModel? GetElement(ExecutionStatusSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ExecutionStatusViewModel> GetFilteredList(ExecutionStatusSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ExecutionStatusViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public ExecutionStatusViewModel? Insert(ExecutionStatusBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ExecutionStatusViewModel? Update(ExecutionStatusBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
