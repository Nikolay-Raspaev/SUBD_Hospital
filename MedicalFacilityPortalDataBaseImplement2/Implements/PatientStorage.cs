using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.BusinessLogicsContracts;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.StoragesContracts;
using MedicalFacilityPortalContracts.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MedicalFacilityPortalDatabaseImplement2.Implements
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