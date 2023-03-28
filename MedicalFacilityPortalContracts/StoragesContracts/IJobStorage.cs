using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalContracts.BusinessLogicsContracts
{
    public interface IJobStorage
    {
        List<JobViewModel> GetFullList();
        List<JobViewModel> GetFilteredList(JobSearchModel model);
        JobViewModel? GetElement(JobSearchModel model);
        JobViewModel? Insert(JobBindingModel model);
        JobViewModel? Update(JobBindingModel model);
        JobViewModel? Delete(JobBindingModel model);
    }
}
