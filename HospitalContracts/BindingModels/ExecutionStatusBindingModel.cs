using HospitalDataModels.Models;
using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class ExecutionStatusBindingModel : IExecutionStatus
    {
        public int Id { get; set; }

        public string ExecutionStatusName { get; set; } = null!;
    }
