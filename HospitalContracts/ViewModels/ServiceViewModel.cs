using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalDataModels.Models;

namespace HospitalContracts.ViewModels
{
    public class ServiceViewModel : IService
    {
        public int Id { get; }

        public string ServiceName { get; }

        public decimal ServicePrice { get; }
    }
}
