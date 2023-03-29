using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.ViewModels
{
    public class ServiceViewModel : IService
    {
        public int Id { get; set; }

        [DisplayName("Название услуги")]
        public string ServicesName { get; set; } = string.Empty;

        [DisplayName("Цена")]
        public decimal ServicesPrice { get; set; }
    }
}
