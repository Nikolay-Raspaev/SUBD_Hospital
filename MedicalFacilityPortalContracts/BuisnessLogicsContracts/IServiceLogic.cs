using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalContracts.BusinessLogicsContracts
{
    public interface IServiceLogic
    {
        List<ServiceViewModel>? ReadList(ServiceSearchModel? model);
        ServiceViewModel? ReadElement(ServiceSearchModel model);
        bool Create(ServiceBindingModel model);
        bool Update(ServiceBindingModel model);
        //удаляем если не с чем не связана
        bool Delete(ServiceBindingModel model);
    }
}