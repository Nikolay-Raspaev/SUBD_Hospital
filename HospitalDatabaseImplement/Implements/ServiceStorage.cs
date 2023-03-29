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
    public class ServiceStorage : IServiceStorage
    {
        public ServiceViewModel? Delete(ServiceBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ServiceViewModel? GetElement(ServiceSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ServiceViewModel> GetFilteredList(ServiceSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<ServiceViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public ServiceViewModel? Insert(ServiceBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ServiceViewModel? Update(ServiceBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
