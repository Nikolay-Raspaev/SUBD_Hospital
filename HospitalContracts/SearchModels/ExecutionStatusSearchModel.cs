using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.SearchModels
{
    public class ExecutionStatusSearchModel
    {
        public int? Id { get; set; }

        public string? ExecutionstatusName { get; set; } = string.Empty;
    }
}
