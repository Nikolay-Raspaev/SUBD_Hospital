using MedContracts.BindingModel;
using MedContracts.SearchModels;
using MedContracts.StoragesContracts;
using MedContracts.ViewModels;
using MedDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace MedDataBaseImplement.Implements
{
    public class ServiceStorage : IServiceStorage
    {
        public ServiceViewModel? Delete(ServiceBindingModel model)
        {
            using var context = new MedBdContext();
            var element = context.Services
                .Include(x => x.Jobs)
                .Include(x => x.DoctorsServices)
                .FirstOrDefault(rec => rec.Id == model.Id);
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
            using var context = new MedBdContext();
            return context.Services
                .Include(x => x.Jobs)
                .Include(x => x.DoctorsServices)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ServiceName) && x.ServicesName == model.ServiceName) ||
                                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public List<ServiceViewModel> GetFilteredList(ServiceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ServiceName))
            {
                return new();
            }
            using var context = new MedBdContext();
            return context.Services
                .Include(x => x.Jobs)
                .Include(x => x.DoctorsServices)
                .ThenInclude(x => x.Services)
                .Where(x => x.ServicesName.Contains(model.ServiceName))
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ServiceViewModel> GetFullList()
        {
            using var context = new MedBdContext();
            return context.Services
                .Include(x => x.Jobs)
                .Include(x => x.DoctorsServices)
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ServiceViewModel? Insert(ServiceBindingModel model)
        {
            using var context = new MedBdContext();
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
            throw new NotImplementedException();
        }
    }
}