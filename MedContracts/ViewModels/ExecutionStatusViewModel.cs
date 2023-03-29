using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.ViewModels
{
    public class ExecutionStatusViewModel : IExecutionStatus
    {
        [DisplayName("Статус контракта")]
        public string ExecutionStatus1 { get; set; } = string.Empty;

        public int Id { get; set; }
    }
}
