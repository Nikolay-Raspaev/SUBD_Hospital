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
    public class ServiceLogic : IServiceLogic
    {
        private readonly IServiceStorage _serviceStorage;
        public ServiceLogic(IServiceStorage ServiceStorage)
        {
            _serviceStorage = ServiceStorage;
        }
        public List<ServiceViewModel>? ReadList(int model)
        {
            var list = model == 0 ? _serviceStorage.GetFullList() : _serviceStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }
        public ServiceViewModel? ReadElement(ServiceSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _serviceStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }
        public bool Create(ServiceBindingModel model)
        {
            CheckModel(model);
            if (_serviceStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Update(ServiceBindingModel model)
        {
            CheckModel(model);
            if (_serviceStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(ServiceBindingModel model)
        {
            CheckModel(model, false);
            if (_serviceStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(ServiceBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ServiceName))
            {
                throw new ArgumentNullException("Нет названия компонента",
               nameof(model.ServiceName));
            }
            if (model.ServicePrice <= 0)
            {
                throw new ArgumentNullException("Цена компонента должна быть больше 0", nameof(model.ServicePrice));
            }
            var element = _serviceStorage.GetElement(new ServiceSearchModel
            {
                ServiceName = model.ServiceName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}
