using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class ContractBindingModel
{
    public int Id { get; set; }

    public DateOnly? ExerciseDate { get; set; }

    public int ExecutionStatusId { get; set; }

    public int PatientId { get; set; }

    public int ContractDoctorsId { get; set; }

    public int ContractServicesId { get; set; }

}
