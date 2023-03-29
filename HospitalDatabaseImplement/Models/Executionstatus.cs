using HospitalContracts.BindingModels;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HospitalDatabaseImplement.Models;

public partial class ExecutionStatus : IExecutionStatus
{
    public int Id { get; set; }

    public string ExecutionStatusName { get; set; } = null!;

    public virtual List<Contract> Contracts { get; } = new List<Contract>();

    public static ExecutionStatus? Create(ExecutionStatusBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return new ExecutionStatus()
        {
            Id = model.Id,
            ExecutionStatusName = model.ExecutionStatusName,
        };
    }

    public static ExecutionStatus Create(ExecutionStatusViewModel model)
    {
        return new ExecutionStatus
        {
            Id = model.Id,
            ExecutionStatusName = model.ExecutionStatusName,
        };
    }

    public void Update(ExecutionStatusBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        ExecutionStatusName = model.ExecutionStatusName;
    }

    public ExecutionStatusViewModel GetViewModel => new()
    {
        Id = Id,
        ExecutionStatusName = ExecutionStatusName,
    };
}
