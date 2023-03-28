

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IPatientModel : IId
    {

        string Surname { get; }

        string Name { get; }

        string Pathronymic { get; }

        DateTime Birttday { get; }

        int PassportSeries { get; }

        int PassportNumber { get; }

        string TelephoneNumber { get; }

        Dictionary<int, IContractModel> PatientContracts { get; }
    }
}
