using MedicalFacilityPortalDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacilityPortalContracts.BindingModels
{
    public class ServiceBindingModel : IServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public Dictionary<int, IJobModel> ServiceJobs { get; set; } = new();

        public Dictionary<int, IDoctorModel> ServiceDoctors { get; set; } = new();
    }
}
