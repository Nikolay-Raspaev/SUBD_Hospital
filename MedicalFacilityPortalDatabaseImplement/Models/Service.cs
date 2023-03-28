using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalDatabaseImplement.Models
{
    public class Service : IServiceModel
    {
        public int Id { get; private set; }

        [Required]
        public string ServiceName { get; private set; } = string.Empty;

        [Required]
        public double ServicePrice { get; private set; }

        [ForeignKey("ServiceId")]
        public virtual List<ServiceJob> Jobs { get; set; } = new();

        public Dictionary<int, IJobModel> ServiceJobs { get; set; } = new();
    }
}
