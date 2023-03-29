using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IExecutionStatus
    {
        public int Id { get; set; }

        public string ExecutionstatusName { get; set; } = null!;

        public virtual List<Contract> Contracts { get; } = new List<Contract>();
    }
}
