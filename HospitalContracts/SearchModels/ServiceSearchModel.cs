using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalDataModels.Models;

namespace HospitalContracts.SearchModels
{
    public class ServiceSearchModel
    {
        public int? Id { get; set; }

        public string? ServiceName { get; set; }
    }
}
