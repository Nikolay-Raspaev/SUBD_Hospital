using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalDatabaseImplement.Models
{
    public class Job : IJobModel
    {
        public int Id { get; private set; }

        [Required]
        public string JobTitle { get; private set; } = string.Empty;

        [ForeignKey("JobId")]
        public virtual List<JobService> Services { get; set; } = new();

        public Dictionary<int, IServiceModel> _jobServices = null;

        [NotMapped]
        public Dictionary<int, IServiceModel> JobServices
        {
            get
            {
                if (_jobServices == null)
                {
                    _jobServices = Services.ToDictionary(recPC => recPC.ServiceId, recPC => (recPC.Service as IServiceModel));
                }
                return _jobServices;
            }
        }

        public static Job Create(MedicalFacilityPortalDatabase context, JobBindingModel model)
        {
            return new Job()
            {
                Id = model.Id,
                JobTitle = model.JobTitle,
                Services = model.JobServices.Select(x => new JobService
                {
                    Service = context.Services.First(y => y.Id == x.Key),
                }).ToList()
            };
        }

        public void Update(JobBindingModel model)
        {
            JobTitle = model.JobTitle;
        }

        public JobViewModel GetViewModel => new()
        {
            Id = Id,
            JobTitle = JobTitle,
            JobServices = JobServices,
        };

    }
}
