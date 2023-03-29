using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class JobBindingModel
    {
        public int Id { get; set; }

        public string JobTitle { get; set; } = null!;

    }
