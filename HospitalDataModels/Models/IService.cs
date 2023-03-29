using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IService
    {
        public int Id { get; set; }

        public string ServicesName { get; set; } = null!;

        public decimal ServicesPrice { get; set; }

        public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

        public virtual List<ServicesJob> ServicesJobs { get; } = new List<ServicesJob>();
    }
}
