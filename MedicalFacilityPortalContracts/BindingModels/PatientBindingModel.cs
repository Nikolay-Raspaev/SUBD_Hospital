using MedicalFacilityPortalDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacilityPortalContracts.BindingModels
{
    public class PatientBindingModel : IPatientModel
    {
        public int Id { get; set; }

        public string Surname { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Pathronymic { get; set; } = string.Empty;

        public DateTime Birttday { get; set; }

        public int PassportSeries { get; set; }

        public int PassportNumber { get; set; }

        public string TelephoneNumber { get; set; } = string.Empty;

        public Dictionary<int, IContractModel> PatientContracts { get; set; } = new();
    }
}
