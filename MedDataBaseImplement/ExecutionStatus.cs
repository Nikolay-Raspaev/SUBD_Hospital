using System;
using System.Collections.Generic;

namespace MedDataBaseImplement;

public partial class ExecutionStatus
{
    public int Id { get; set; }

    public string ExecutionStatus1 { get; set; } = null!;

    public virtual List<Contract> Contracts { get; } = new List<Contract>();
}
