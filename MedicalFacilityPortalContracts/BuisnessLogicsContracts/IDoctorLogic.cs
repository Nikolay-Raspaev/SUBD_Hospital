using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalContracts.BusinessLogicsContracts
{
    public interface IDoctorLogic
    {
        List<DoctorViewModel>? ReadList(DoctorSearchModel? model);
        DoctorViewModel? ReadElement(DoctorSearchModel model);
        bool Create(DoctorBindingModel model);
        bool Update(DoctorBindingModel model);
        //удаляем если не с чем не связана
        bool Delete(DoctorBindingModel model);
        bool ReleaseTheCandidate(ContractBindingModel model);
        bool ReleaseTheDoctorate(ContractBindingModel model);
    }
}