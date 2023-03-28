using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalDatabaseImplement.Models
{
    public class ServiceJob
    {
        public int Id { get; private set; }

        [Required]
        public int ServiceId { get; private set; }

        [Required]
        public int JobId { get; private set; }
    }
}
