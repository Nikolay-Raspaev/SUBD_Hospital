using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using HospitalDatabaseImplement.StoragesContracts;
using Microsoft.EntityFrameworkCore;
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

        public List<ServiceViewModel> GetFilteredList(int JobId)
        {
            using var context = new HospitalBdContext();
            List<Service> listService = context.Services
                    .Include(x => x.ServicesJobs)
                    .ToList();
            List<Service> listServiceViewModels = new List<Service>();
            foreach (var service in listService)
            {
                foreach (var serviceJob in service.ServicesJobs)
                {
                    if (serviceJob.JobId == JobId)
                    {
                        listServiceViewModels.Add(service);
                        break;
                    }
                }
            }

            return listServiceViewModels
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
            using var context = new HospitalBdContext();
            model.Id = context.Services.Count() > 0 ? context.Services.Max(x => x.Id) + 1 : 1;
            var newService = Service.Create(model);
            if (newService == null)
            {
                return null;
            }
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
