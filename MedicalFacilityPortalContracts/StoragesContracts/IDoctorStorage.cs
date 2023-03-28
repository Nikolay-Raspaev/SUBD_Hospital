using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalContracts.StoragesContracts
{
    public interface IDoctorStorage
    {
        List<DoctorViewModel> GetFullList();
        List<DoctorViewModel> GetFilteredList(DoctorSearchModel model);
        DoctorViewModel? GetElement(DoctorSearchModel model);
        DoctorViewModel? Insert(DoctorBindingModel model);
        DoctorViewModel? Update(DoctorBindingModel model);
        DoctorViewModel? Delete(DoctorBindingModel model);
    }
}