

using MedicalFacilityPortalDataModels.Enums;
using System.ComponentModel;

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IDoctorModel : IId
    {
        string Surname { get; }

        string Name { get; }

        string Patronymic { get; }

        DateTime Birthdate { get;  }

        int PassportSeries { get; }

        int PassportNumber { get; }

        string TelephoneNumber { get;  }

        string Education { get;  }

        int JobId { get;  }

        AcademicDegree AcademicDegree { get;  }
    }
}
