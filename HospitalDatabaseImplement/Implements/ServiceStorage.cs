using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.Implements
{
    public class ServiceStorage : IServiceStorage
    {
        public ServiceViewModel? Delete(ServiceBindingModel model)
        {
            using var context = new HospitalBdContext();
            var element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Services.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ServiceViewModel? GetElement(ServiceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ServiceName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            return context.Services
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ServiceName) && x.ServiceName == model.ServiceName) ||
                    (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public List<ServiceViewModel> GetFilteredList(ServiceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ServiceName))
            {
                return new();
            }
            using var context = new HospitalBdContext();
            return context.Services
                    .Where(x => x.ServiceName.Contains(model.ServiceName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<ServiceViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            return context.Services
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public ServiceViewModel? Insert(ServiceBindingModel model)
        {
            var newService = Service.Create(model);
            if (newService == null)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            context.Services.Add(newService);
            context.SaveChanges();
            return newService.GetViewModel;
        }

        public ServiceViewModel? Update(ServiceBindingModel model)
        {
            using var context = new HospitalBdContext();
            var service = context.Services.FirstOrDefault(x => x.Id == model.Id);
            if (service == null)
            {
                return null;
            }
            service.Update(model);
            context.SaveChanges();
            return service.GetViewModel;
        }
    }
}
