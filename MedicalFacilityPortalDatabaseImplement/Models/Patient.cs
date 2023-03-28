using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalDatabaseImplement.Models
{
    public class Patient : IPatientModel
    {
        public int Id { get; private set; }

        [Required]
        public string Surname { get; private set; } = string.Empty;

        [Required]
        public string Name { get; private set; } = string.Empty;

        [Required]
        public string Pathronymic { get; private set; } = string.Empty;

        [Required]
        public DateTime Birttday { get; private set; }

        [Required]
        public int PassportSeries { get; private set; }

        [Required]
        public int PassportNumber { get; private set; }

        public string TelephoneNumber { get; private set; } = string.Empty;

        [ForeignKey("ContractId")]
        public virtual List<Contract> Contracts { get; set; } = new();

        public Dictionary<int, IContractModel> PatientContracts { get; set; } = new();
    }
}
