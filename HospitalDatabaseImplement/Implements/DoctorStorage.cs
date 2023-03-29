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
    public class DoctorStorage : IDoctorStorage
    {
        public DoctorViewModel? Delete(DoctorBindingModel model)
        {
            throw new NotImplementedException();
        }

        public DoctorViewModel? GetElement(DoctorSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<DoctorViewModel> GetFilteredList(DoctorSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<DoctorViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public DoctorViewModel? Insert(DoctorBindingModel model)
        {
            throw new NotImplementedException();
        }

        public DoctorViewModel? Update(DoctorBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
