using HospitalDataModels.Models;
using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class ExecutionStatus : IExecutionStatus
{
    public int Id { get; set; }

    public string ExecutionstatusName { get; set; } = null!;

    public virtual List<Contract> Contracts { get; } = new List<Contract>();
}
