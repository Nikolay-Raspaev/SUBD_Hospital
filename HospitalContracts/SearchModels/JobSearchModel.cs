using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.SearchModels
{
    public class JobSearchModel
    {
        public int? Id { get; set; }

        public string? JobTitle { get; set; } = string.Empty;
    }
}
