using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalContracts.BindingModels;

namespace MedicalFacilityPortalContracts.BusinessLogicsContracts
{
    public interface IPatientStorage
    {
        List<PatientViewModel> GetFullList();
        List<PatientViewModel> GetFilteredList(PatientSearchModel model);
        PatientViewModel? GetElement(PatientSearchModel model);
        PatientViewModel? Insert(PatientBindingModel model);
        PatientViewModel? Update(PatientBindingModel model);
        PatientViewModel? Delete(PatientBindingModel model);
    }
}
