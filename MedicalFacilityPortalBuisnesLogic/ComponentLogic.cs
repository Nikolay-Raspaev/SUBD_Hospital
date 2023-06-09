﻿using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.BusinessLogicsContracts;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalBuisnesLogic.BusinessLogics
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IServiceStorage _serviceStorage;

        public bool Create(ServiceBindingModel model)
        {
            CheckModel(model);
            if (_serviceStorage.Insert(model) == null)
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

        public List<ServiceViewModel>? ReadList(ServiceSearchModel? model)
        {
            var list = _serviceStorage.GetFullList();/*: _serviceStorage.GetFilteredList(model)*/
            if (list == null)
            {
                return null;
            }
            return list;
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
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentNullException("Нет названия компонента",
               nameof(model.Name));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена компонента должна быть больше 0", nameof(model.Price));
            }
            var element = _serviceStorage.GetElement(new ServiceSearchModel
            {
                Id = model.Id,
                ServiceName = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}