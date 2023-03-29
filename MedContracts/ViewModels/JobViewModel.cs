using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.ViewModels
{
    public class JobViewModel : IJob
    {
        [DisplayName("Название должности")]
        public string JobTitle { get; set; } = string.Empty;

        public int Id { get; set; }

        public Dictionary<int, IService> JobServices { get; set; } = new();
    }
}
