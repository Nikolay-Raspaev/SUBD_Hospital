using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class ServiceBindingModel
    {
        public int Id { get; set; }

        public string ServiceName { get; set; } = null!;

        public decimal ServicePrice { get; set; }
    }
