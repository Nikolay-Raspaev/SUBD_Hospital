

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IPatientModel : IId
    {

        string Surname { get; }

        string Name { get; }

        string Patronymic { get; }

        DateTime Birthdate { get; }

        int PassportSeries { get; }

        int PassportNumber { get; }

        string TelephoneNumber { get; }

    }
}
