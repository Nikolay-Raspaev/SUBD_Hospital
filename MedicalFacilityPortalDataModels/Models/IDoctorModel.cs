

using FoodOrdersDataModels.Enums;
using System.ComponentModel;

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IDoctorModel : IId
    {
        string Surname { get; }

        string Name { get; }

        string Pathronymic { get; }

        DateTime Birttday{ get;  }

        int PassportSeries { get; }

        int PassportNumber { get; }

        string TelephoneNumber { get;  }

        string Education { get;  }

        int JobId { get;  }

        AcademicDegree AcademicDegree { get;  }

        Dictionary<int, IServiceModel> DoctorServices { get; }
    }
}
