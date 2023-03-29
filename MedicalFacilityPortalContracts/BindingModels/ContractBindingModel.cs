using MedicalFacilityPortalDataModels.Enums;
using MedicalFacilityPortalDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalFacilityPortalContracts.BindingModels
{
    public class ContractBindingModel : IContractModel
    {
        public int Id { get; set; }

        public DateTime? ExerciseDate { get; set; } = DateTime.Now;

        public ContractStatus ExecutionStatus { get; set; } = ContractStatus.Неизвестен;

        public int PatientId { get; set; }

        public int DoctorsServicesId { get; set; }
        public decimal Price { get; set; }
    }
}
