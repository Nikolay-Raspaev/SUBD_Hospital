

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IServiceModel : IId
    {
        int Id { get; }

        string ServiceName { get; }

        double ServicePrice { get; }

        Dictionary<int, IJobModel> ServiceJobs { get; }

        Dictionary<int, IDoctorModel> ServiceDoctors { get; }
    }
}
