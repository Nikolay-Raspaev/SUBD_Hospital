using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.SearchModels
{
    public class PatientSearchModel
    {
        public int? Id { get; set; }

        public string? Passport { get; set; } = string.Empty;
    }
}
