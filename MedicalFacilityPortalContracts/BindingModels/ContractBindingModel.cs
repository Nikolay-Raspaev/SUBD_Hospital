using MedicalFacilityPortalDataModels.Enums;
using MedicalFacilityPortalDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace MedicalFacilityPortalContracts.BindingModels
{
    public class ContractBindingModel : IContractModel
    {
        public int Id { get; set; }

        public DateTime ExecutionDate { get; set; } = DateTime.Now;

        public ContractStatus ExecutoinStatus { get; set; } = ContractStatus.Неизвестен;

        public int PatientId { get; set; }

        public int DoctorServiceId { get; set; }
        public double ContractPrice { get; set; }
    }
}
