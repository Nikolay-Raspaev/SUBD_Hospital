using FoodOrdersDataModels.Enums;
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
    public class Doctor : IDoctorModel
    {
        public int Id { get; private set; }

        [Required]
        public string Surname { get; private set; } = string.Empty;

        [Required]
        public string Name { get; private set; } = string.Empty;

        [Required]
        public string Pathronymic { get; private set; } = string.Empty;

        [Required]
        public DateTime Birttday{ get; private set; }

        [Required]
        public int PassportSeries { get; private set; }

        [Required]
        public int PassportNumber { get; private set; }

        public string TelephoneNumber { get; private set; } = string.Empty;

        [Required]
        public string Education { get; private set; } = string.Empty;

        [Required]
        public int JobId { get; private set; }

        public AcademicDegree AcademicDegree { get; private set; }

        [ForeignKey("DoctorId")]
        public virtual List<DoctorService> Services { get; set; } = new();

        public Dictionary<int, IServiceModel> DoctorServices { get; set; } = new();
    }
}
