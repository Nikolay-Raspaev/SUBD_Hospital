using MedicalFacilityPortalDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacilityPortalContracts.BindingModels
{
    public class ServiceBindingModel : IServiceModel
    {
        public int Id { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public double ServicePrice { get; set; }

        public Dictionary<int, IJobModel> ServiceJobs { get; set; } = new();

        public Dictionary<int, IDoctorModel> ServiceDoctors { get; set; } = new();
    }
}
