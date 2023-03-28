using FoodOrdersDataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalFacilityPortalDataModels.Models;
using MedicalFacilityPortalContracts.BindingModels;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;

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

        public Dictionary<int, IServiceModel>? _doctorServices = null;

        [NotMapped]
        public Dictionary<int, IServiceModel> DoctorServices
        {
            get
            {
                if (_doctorServices == null)
                {
                    _doctorServices = Services.ToDictionary(recPC => recPC.ServiceId, recPC => (recPC.Service as IServiceModel));
                }
                return _doctorServices;
            }
        }

        public static Doctor Create(MedicalFacilityPortalDatabase context, DoctorBindingModel model)
        {
            return new Doctor()
            {
                Id = model.Id,
                Surname = model.Surname,
                Pathronymic = model.Pathronymic,
                Name = model.Name,
                Birttday = model.Birttday,
                PassportSeries = model.PassportSeries,
                PassportNumber = model.PassportNumber,
                Education = model.Education,
                JobId = model.JobId,
                AcademicDegree = model.AcademicDegree,
                Services = model.DoctorServices.Select(x => new DoctorService
                {
                    Service = context.Services.First(y => y.Id == x.Key),
                }).ToList()
            };
        }
        //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой
        public void Update(DoctorBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Surname = model.Surname;
            Pathronymic =  model.Pathronymic;
            Name = model.Name;
            Birttday = model.Birttday;
            PassportSeries = model.PassportSeries;
            PassportNumber = model.PassportNumber;
            Education = model.Education;
            JobId = model.JobId;
            AcademicDegree = model.AcademicDegree;
        }
    }
}
