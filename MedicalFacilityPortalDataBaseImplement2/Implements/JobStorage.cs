using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.BusinessLogicsContracts;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.StoragesContracts;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalDatabaseImplement2.Implements
{
    public class JobStorage : IJobStorage
    {
        public JobViewModel? Delete(JobBindingModel model)
        {
            throw new NotImplementedException();
        }

        public JobViewModel? GetElement(JobSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<JobViewModel> GetFilteredList(JobSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<JobViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public JobViewModel? Insert(JobBindingModel model)
        {
            throw new NotImplementedException();
        }

        public JobViewModel? Update(JobBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}