using HospitalContracts.BindingModels;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HospitalDatabaseImplement.Models;

public partial class Contract : IContract
{
    public int Id { get; set; }

    public DateOnly? ExerciseDate { get; set; }

    public int ExecutionStatusId { get; set; }

    public int PatientId { get; set; }

    public int ContractDoctorsId { get; set; }

    public int ContractServicesId { get; set; }

    public virtual DoctorsService ContractNavigation { get; set; } = null!;

    public virtual ExecutionStatus ExecutionStatus { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public static Contract Create(ContractBindingModel model)
    {
        return new Contract()
        {
            Id = model.Id,
            ExerciseDate = model.ExerciseDate,
            ExecutionStatusId = model.ExecutionStatusId,
            PatientId = model.PatientId,
            ContractDoctorsId = model.ContractDoctorsId,
            ContractServicesId = model.ContractServicesId,
        };
    }

    public void Update(ContractBindingModel model)
    {
        Id = model.Id;
        ExerciseDate = model.ExerciseDate;
        ExecutionStatusId = model.ExecutionStatusId;
        PatientId = model.PatientId;
        ContractDoctorsId = model.ContractDoctorsId;
        ContractServicesId = model.ContractServicesId;
    }
    public ContractViewModel GetViewModel => new()
    {
        Id = Id,
        ExerciseDate = ExerciseDate,
        ExecutionStatusName = ExecutionStatus.ExecutionStatusName,
        PatientFIO = Patient.Name + " " + Patient.Patronymic,
        DoctorFIO = ContractNavigation.Doctors.Name + " " + ContractNavigation.Doctors.Patronymic,
        ServiceName = ContractNavigation.Services.ServiceName,
        ServicePrice = ContractNavigation.Services.ServicePrice
    };
}
