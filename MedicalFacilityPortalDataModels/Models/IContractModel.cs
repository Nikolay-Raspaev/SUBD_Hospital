

using MedicalFacilityPortalDataModels.Enums;

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IContractModel : IId
    {

        DateTime ExecutionDate { get; }

        ContractStatus ExecutoinStatus { get; }

        int PatientId { get; }

        int DoctorServiceId { get; }

        double ContractPrice { get; }

    }
}
