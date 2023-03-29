using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalDataModels.Models;

namespace HospitalContracts.ViewModels
{
    public class ServiceViewModel : IService
    {
        public int Id { get; }

        [DisplayName("Название услуги")]
        public string ServiceName { get; }

        [DisplayName("Цена услуги")]
        public decimal ServicePrice { get; }
    }
}
