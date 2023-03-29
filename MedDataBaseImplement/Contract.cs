using System;
using System.Collections.Generic;

namespace MedDataBaseImplement;

public partial class Contract
{
    public int Id { get; set; }

    public DateOnly? ExerciseDate { get; set; }

    public int ExecutionStatusId { get; set; }

    public int PatientId { get; set; }

    public int ContractDoctorsId { get; set; }

    public int ContractServicesId { get; set; }

    public virtual Doctorsservice ContractNavigation { get; set; } = null!;

    public virtual Executionstatus ExecutionStatus { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
