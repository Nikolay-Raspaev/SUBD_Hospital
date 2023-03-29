using MedDataModels.Models;
using System;
using System.Collections.Generic;

namespace MedDataBaseImplement.Models;

public partial class ExecutionStatus : IExecutionStatus
{
    public int Id { get; set; }

    public string ExecutionStatus1 { get; set; } = null!;

    public virtual List<Contract> Contracts { get; } = new List<Contract>();
}
