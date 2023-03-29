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
    public class ContarctStorage : IContractStorage
    {
        public ContractViewModel? Delete(ContractBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ContractViewModel? GetElement(ContractSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ContractViewModel> GetFilteredList(ContractSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ContractViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public ContractViewModel? Insert(ContractBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ContractViewModel? Update(ContractBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
