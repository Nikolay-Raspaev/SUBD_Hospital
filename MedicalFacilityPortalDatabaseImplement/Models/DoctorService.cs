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
    public class DoctorService
    {
        public int Id { get; private set; }

        [Required]
        public int DoctorId { get; private set; }

        [Required]
        public int ServiceId { get; private set; }

        [ForeignKey("DoctorServiceId")]
        public virtual List<Contract> Contracts { get; set; } = new();
    }
}
