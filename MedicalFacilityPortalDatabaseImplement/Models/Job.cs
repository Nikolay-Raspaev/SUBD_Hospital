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
    public class Job : IJobModel
    {
        public int Id { get; private set; }

        [Required]
        public string JobTitle { get; private set; } = string.Empty;

        [ForeignKey("JobId")]
        public virtual List<ServiceJob> Services { get; set; } = new();

        public Dictionary<int, IServiceModel> JobServices { get; set; } = new();
    }
}
