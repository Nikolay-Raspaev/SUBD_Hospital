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
    public class ExecutionStatusLogic : IExecutionStatusLogic
    {
        private readonly IExecutionStatusStorage _executionStatusStorage;
        public  ExecutionStatusLogic(IExecutionStatusStorage  ExecutionStatusStorage)
        {
            _executionStatusStorage =  ExecutionStatusStorage;
        }
        public List< ExecutionStatusViewModel>? ReadList( ExecutionStatusSearchModel? model)
        {
            var list = model == null ? _executionStatusStorage.GetFullList() : _executionStatusStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }
        public  ExecutionStatusViewModel? ReadElement( ExecutionStatusSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _executionStatusStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }
        public bool Create( ExecutionStatusBindingModel model)
        {
            CheckModel(model);
            if (_executionStatusStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Update( ExecutionStatusBindingModel model)
        {
            CheckModel(model);
            if (_executionStatusStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete( ExecutionStatusBindingModel model)
        {
            CheckModel(model, false);
            if (_executionStatusStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel( ExecutionStatusBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ExecutionStatusName))
            {
                throw new ArgumentNullException("Нет названия компонента",
               nameof(model. ExecutionStatusName));
            }

            var element = _executionStatusStorage.GetElement(new  ExecutionStatusSearchModel
            {
                 ExecutionStatusName = model. ExecutionStatusName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}
