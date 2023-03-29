using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IJob
    {
        public int Id { get; set; }

        public string JobTitle { get; set; } = null!;

        public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

        public virtual List<ServicesJob> ServicesJobs { get; } = new List<ServicesJob>();

        Dictionary<int, (IComponentModel, int)> DishComponents { get; }
    }
}
