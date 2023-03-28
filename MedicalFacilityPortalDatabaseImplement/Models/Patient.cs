using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
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

        [ForeignKey("PatientId")]
        public virtual List<Contract> Contracts { get; set; } = new();

        public Dictionary<int, IContractModel>? _patientContracts = null;

        [NotMapped]
        public Dictionary<int, IContractModel> PatientContracts
        {
            get
            {
                if (_patientContracts == null)
                {
                    _patientContracts = Contracts.ToDictionary(recPC => recPC.Id, recPC => (recPC as IContractModel));
                }
                return _patientContracts;
            }
        }

        public static Patient Create(MedicalFacilityPortalDatabase context, PatientBindingModel model)
        {
            return new Patient()
            {
                Id = model.Id,
                Surname = model.Surname,
                Name = model.Name,
                Pathronymic = model.Pathronymic,
                Birttday = model.Birttday,
                PassportSeries = model.PassportSeries,
                PassportNumber = model.PassportNumber,
                TelephoneNumber = model.TelephoneNumber,
                Contracts = model.PatientContracts.Select(x =>  context.Contracts.First(y => y.Id == x.Key)).ToList()
            };
        }

        public PatientViewModel GetViewModel => new()
        {
            Id = Id,
            Surname = Surname,
            Name = Name,
            Pathronymic = Pathronymic,
            Birttday = Birttday,
            PassportSeries = PassportSeries,
            PassportNumber = PassportNumber,
            TelephoneNumber = TelephoneNumber,
            PatientContracts = PatientContracts
        };

    }
}
