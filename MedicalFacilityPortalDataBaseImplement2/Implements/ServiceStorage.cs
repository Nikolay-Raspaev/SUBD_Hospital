using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.BusinessLogicsContracts;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.StoragesContracts;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalDataBaseImplement2;
using Microsoft.EntityFrameworkCore;

namespace MedicalFacilityPortalDatabaseImplement2.Implements
{
    public class ServiceStorage : IServiceStorage
    {
        public ServiceViewModel? Delete(ServiceBindingModel model)
        {
            using var context = new MedDB();
            var element = context.Services
                .Include(x => x.Servicesjobs)
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
            using var context = new MedDB();
            return context.Services
                .Include(x => x.Servicesjobs)
                .Include(x => x.DoctorsServices)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ServiceName) && x.Name == model.ServiceName) ||
                                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public List<ServiceViewModel> GetFilteredList(ServiceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ServiceName))
            {
                return new();
            }
            using var context = new MedDB();
            return context.Services
                .Include(x => x.Servicesjobs)
                .Include(x => x.DoctorsServices)
                .Where(x => x.Name.Contains(model.ServiceName))
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ServiceViewModel> GetFullList()
        {
            using var context = new MedDB();
            return context.Services
                .Include(x => x.Servicesjobs)
                .Include(x => x.DoctorsServices)
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ServiceViewModel? Insert(ServiceBindingModel model)
        {
            using var context = new MedDB();
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
