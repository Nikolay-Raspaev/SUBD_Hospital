using HospitalContracts.BindingModels;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogic
{
    public class ContractLogic : IContractLogic
    {
        private readonly IContractStorage _contractStorage;
        public ContractLogic(IContractStorage ContractStorage)
        {
            _contractStorage = ContractStorage;
        }
        public List<ContractViewModel>? ReadList(ContractSearchModel? model)
        {
            var list = _contractStorage.GetFullList();
            if (list == null)
            {
                return null;
            }
            return list;
        }
        public ContractViewModel? ReadElement(ContractSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _contractStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }
        public bool Create(ContractBindingModel model)
        {
            CheckModel(model);
            if (_contractStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Update(ContractBindingModel model)
        {
            CheckModel(model);
            if (_contractStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(ContractBindingModel model)
        {
            CheckModel(model, false);
            if (_contractStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(ContractBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }
    }
}
