

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IJobModel : IId
    {
        public string JobTitle { get; }

        Dictionary<int, IServiceModel> JobServices { get; }
    }
}
