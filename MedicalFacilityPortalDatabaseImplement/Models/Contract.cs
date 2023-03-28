using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalDataModels.Enums;
using MedicalFacilityPortalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalFacilityPortalDatabaseImplement.Models
{
    public class Contract : IContractModel
    {
        public int Id { get; private set; }

        public DateTime ExecutionDate { get; private set; }

        [Required]
        public ContractStatus ExecutoinStatus { get; private set; }

        [Required]
        public int PatientId { get; private set; }

        public int DoctorServiceId { get; private set; }

        public double ContractPrice { get; set; }

        public static Contract? Create(ContractBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Contract()
            {
                Id = model.Id,
                ExecutionDate = model.ExecutionDate,
                ExecutoinStatus = model.ExecutoinStatus,
                PatientId = model.PatientId,
                DoctorServiceId = model.DoctorServiceId,
                ContractPrice = model.ContractPrice
            };
        }

        public void Update(ContractBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ExecutoinStatus = model.ExecutoinStatus;
            ExecutionDate = model.ExecutionDate;
        }

        public ContractViewModel GetViewModel => new()
        {
            Id = Id,
            ExecutionDate = ExecutionDate,
            ExecutoinStatus = ExecutoinStatus,
            PatientId = PatientId,
            DoctorServiceId = DoctorServiceId,
            ContractPrice = ContractPrice
        };

    }
}
