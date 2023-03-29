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
    public class PatientStorage : IPatientStorage
    {
        public PatientViewModel? Delete(PatientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public PatientViewModel? GetElement(PatientSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<PatientViewModel> GetFilteredList(PatientSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<PatientViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public PatientViewModel? Insert(PatientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public PatientViewModel? Update(PatientBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
