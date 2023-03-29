using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

    public class AcademicRankBindingModel
    {
        public int Id { get; set; }

        public string AcademicRankName { get; set; } = null!;
    }