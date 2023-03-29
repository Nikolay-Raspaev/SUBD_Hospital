using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class ExecutionStatusBindingModel
    {
        public int Id { get; set; }

        public string ExecutionstatusName { get; set; } = null!;
    }
