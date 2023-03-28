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
    public class Service : IServiceModel
    {
        public int Id { get; private set; }

        [Required]
        public string ServiceName { get; private set; } = string.Empty;

        [Required]
        public double ServicePrice { get; private set; }

        [ForeignKey("ServiceId")]
        public virtual List<DoctorService> Doctors { get; set; } = new();

        public Dictionary<int, IDoctorModel>? _serviceDoctors = null;

        [NotMapped]
        public Dictionary<int, IDoctorModel> ServiceDoctors
        {
            get
            {
                if (_serviceDoctors == null)
                {
                    _serviceDoctors = Doctors.ToDictionary(recPC => recPC.DoctorId, recPC => (recPC.Doctor as IDoctorModel));
                }
                return _serviceDoctors;
            }
        }

        [ForeignKey("ServiceId")]
        public virtual List<JobService> Jobs { get; set; } = new();

        public Dictionary<int, IJobModel> _serviceJobs { get; set; } = null;

        [NotMapped]
        public Dictionary<int, IJobModel> ServiceJobs
        {
            get
            {
                if (_serviceJobs == null)
                {
                    _serviceJobs = Jobs.ToDictionary(recPC => recPC.JobId, recPC => (recPC.Job as IJobModel));
                }
                return _serviceJobs;
            }
        }

        public static Service Create(MedicalFacilityPortalDatabase context, ServiceBindingModel model)
        {
            return new Service()
            {
                Id = model.Id,
                ServiceName = model.ServiceName,
                ServicePrice = model.ServicePrice,
                Jobs = model.ServiceJobs.Select(x => new JobService
                {
                    Job = context.Jobs.First(y => y.Id == x.Key),
                }).ToList()
            };
        }

        public void UpdateServices(MedicalFacilityPortalDatabase context, ServiceBindingModel model)
        {
            var doctorService = context.DoctorsServices.Where(rec => rec.ServiceId == model.Id).ToList();
            if (doctorService != null && doctorService.Count > 0)
            {   // удалили те в бд, которых нет в модели
                context.DoctorsServices.RemoveRange(doctorService.Where(rec => !model.ServiceDoctors.ContainsKey(rec.ServiceId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateService in doctorService)
                {
                    model.ServiceDoctors.Remove(updateService.ServiceId);
                }
                context.SaveChanges();
            }
            var service = context.Services.First(x => x.Id == Id);
            //добавляем в бд блюда которые есть в моделе, но ещё нет в бд
            foreach (var ds in model.ServiceDoctors)
            {
                context.DoctorsServices.Add(new DoctorService
                {
                    Service = service,
                    Doctor = context.Doctors.First(x => x.Id == ds.Key),
                });
                context.SaveChanges();
            }
            _serviceDoctors = null;
        }

        public void Update(ServiceBindingModel model)
        {
            ServiceName = model.ServiceName;
            ServicePrice = model.ServicePrice;
        }
        public ServiceViewModel GetViewModel => new()
        {
            Id = Id,
            ServiceName = ServiceName,
            ServicePrice = ServicePrice,
            ServiceJobs = ServiceJobs
        };
    }
}
