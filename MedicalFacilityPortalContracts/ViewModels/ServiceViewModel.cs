using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalContracts.ViewModels
{
    public class ServiceViewModel : IServiceModel
    {
        public int Id { get; set; }

        [DisplayName("Название услуги")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, IJobModel> ServiceJobs { get; set; } = new();

        public Dictionary<int, IDoctorModel> ServiceDoctors { get; set; } = new();
    }
}
