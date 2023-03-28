using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalContracts.ViewModels
{
    public class PatientViewModel : IPatientModel
    {
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        public string Surname { get; set; } = string.Empty;

        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Отчество")]
        public string Pathronymic { get; set; } = string.Empty;

        [DisplayName("Дата рождения")]
        public DateTime Birttday { get; set; }
        
        [DisplayName("Серия паспорта")]
        public int PassportSeries { get; set; }

        [DisplayName("Номер паспорта")]
        public int PassportNumber { get; set; }

        [DisplayName("Номер телефона")]
        public string TelephoneNumber { get; set; } = string.Empty;

        public Dictionary<int, IContractModel> PatientContracts { get; set; } = new();

    }
}
