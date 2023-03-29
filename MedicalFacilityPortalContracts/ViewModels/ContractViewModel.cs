using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MedicalFacilityPortalDataModels.Enums;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalContracts.ViewModels
{
    public class ContractViewModel : IContractModel
    {
        public int Id { get; set; }

        [DisplayName("Дата исполнения")]
        public DateTime? ExerciseDate { get; set; }

        [DisplayName("Статус контракта")]
        public ContractStatus ExecutionStatus { get; set; }

        [DisplayName("ФИО пациента")]
        public int FIOPatient { get; set; }

        public int PatientId { get; set; }

        [DisplayName("Оказанная услуга")]
        public int DoctorsServicesId { get; set; }

        [DisplayName("Цена услуги")]
        public decimal Price { get; set; }

    }
}
