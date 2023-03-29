using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class ExecutionStatus
{
    public int Id { get; set; }

    public string ExecutionstatusName { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();
}
