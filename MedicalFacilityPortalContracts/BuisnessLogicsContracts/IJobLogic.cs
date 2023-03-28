using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalContracts.BusinessLogicsContracts
{
    public interface IJobLogic
    {
        List<JobViewModel>? ReadList(JobSearchModel? model);
        bool Create(JobBindingModel model);
        bool Update(JobBindingModel model);
        //удаляем если не с чем не связана
        bool Delete(JobBindingModel model);
    }
}
