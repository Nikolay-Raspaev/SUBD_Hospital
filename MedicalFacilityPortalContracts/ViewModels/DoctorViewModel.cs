using FoodOrdersDataModels.Enums;
using MedicalFacilityPortalDataModels.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacilityPortalContracts.ViewModels
{
    public class DoctorViewModel : IDoctorModel
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

        [DisplayName("Образование")]
        public string Education { get; set; } = string.Empty;

        [DisplayName("Профессия")]

        public int JobTitle { get; set; }

        public int JobId { get; set; }

        [DisplayName("Учёная степень")]
        public AcademicDegree AcademicDegree { get; set; }

        public Dictionary<int, IServiceModel> DoctorServices { get; set; } = new();
    }
}
