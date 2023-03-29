using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
    public class JobViewModel : IJob
    {
        public int Id { get; set; }

        [DisplayName("Название должности")]
        public string JobTitle { get; set; } = string.Empty;
    }
}
