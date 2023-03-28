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
        public DateTime ExecutionDate { get; set; }

        [DisplayName("Статус контракта")]
        public ContractStatus ExecutoinStatus { get; set; }

        [DisplayName("ФИО пациента")]
        public int FIOPatient { get; set; }

        public int PatientId { get; set; }

        [DisplayName("Оказанная услуга")]
        public int DoctorServiceId { get; set; }

        [DisplayName("Цена услуги")]
        public double ContractPrice { get; set; }

    }
}
