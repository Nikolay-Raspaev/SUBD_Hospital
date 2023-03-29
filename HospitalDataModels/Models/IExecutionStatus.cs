using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IExecutionStatus
    {
        int Id { get; }

        string ExecutionstatusName { get; }
    }
}
