using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalDataModels.Enums;
using System;
using System.Collections.Generic;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class Contract
{
    public int Id { get; set; }

    public DateTime? ExerciseDate { get; set; }

    public ContractStatus ExecutionStatus { get; set; }

    public int PatientId { get; set; }

    public int DoctorsServicesId { get; set; }

    public decimal Price { get; set; }

    public virtual DoctorsServices DoctorsServices { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public static Contract? Create(ContractBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return new Contract()
        {
            Id = model.Id,
            ExerciseDate = model.ExerciseDate,
            ExecutionStatus = model.ExecutionStatus,
            PatientId = model.PatientId,
            DoctorsServicesId = model.DoctorsServicesId,
            Price = model.Price
        };
    }

    public void Update(ContractBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        ExecutionStatus = model.ExecutionStatus;
        ExerciseDate = model.ExerciseDate;
    }


    public ContractViewModel GetViewModel => new()
    {
        Id = Id,
        ExerciseDate = ExerciseDate,
        ExecutionStatus = ExecutionStatus,
        PatientId = PatientId,
        DoctorsServicesId = DoctorsServicesId,
        Price = Price
    };
}
