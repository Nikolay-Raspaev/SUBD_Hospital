using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
    public class DoctorServiceViewModel : IDoctorService
    {
        public int DoctorsId { get; set; }

        public int ServicesId { get; set; }

        [DisplayName("Имя доктора")]
        public string DoctorName { get; set; } = string.Empty;

        [DisplayName("Название услуги")]
        public string ServiceName { get; set; } = string.Empty;
    }
}
