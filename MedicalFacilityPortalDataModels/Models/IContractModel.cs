

using MedicalFacilityPortalDataModels.Enums;

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IContractModel : IId
    {

        DateTime? ExerciseDate { get; }

        ContractStatus ExecutionStatus { get; }

        int PatientId { get; }

        int DoctorsServicesId { get; }

        decimal Price { get; }

    }
}
