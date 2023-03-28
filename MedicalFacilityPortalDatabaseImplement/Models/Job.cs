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
            if (model == null)
            {
                return;
            }
            JobTitle = model.JobTitle;
        }

        //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой
        public void UpdateServices(MedicalFacilityPortalDatabase context, JobBindingModel model)
        {
            var jobService = context.JobsServices.Where(rec => rec.JobId == model.Id).ToList();
            if (jobService != null && jobService.Count > 0)
            {   // удалили те в бд, которых нет в модели
                context.JobsServices.RemoveRange(jobService.Where(rec => !model.JobServices.ContainsKey(rec.ServiceId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateService in jobService)
                {
                    model.JobServices.Remove(updateService.ServiceId);
                }
                context.SaveChanges();
            }
            var job = context.Jobs.First(x => x.Id == Id);
            //добавляем в бд блюда которые есть в моделе, но ещё нет в бд
            foreach (var ds in model.JobServices)
            {
                context.JobsServices.Add(new JobService
                {
                    Job = job,
                    Service = context.Services.First(x => x.Id == ds.Key),
                });
                context.SaveChanges();
            }
            _jobServices = null;
        }

        public JobViewModel GetViewModel => new()
        {
            Id = Id,
            JobTitle = JobTitle,
            JobServices = JobServices,
        };

    }
}
