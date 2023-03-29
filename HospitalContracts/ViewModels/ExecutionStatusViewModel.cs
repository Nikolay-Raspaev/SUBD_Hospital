using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
    public class ExecutionStatusViewModel : IExecutionStatus
    {
        public int Id { get; }

        public string ExecutionstatusName { get; }
    }
}
