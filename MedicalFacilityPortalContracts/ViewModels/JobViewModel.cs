using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalFacilityPortalDataModels.Models;

namespace MedicalFacilityPortalContracts.ViewModels
{
    public class JobViewModel : IJobModel
    {
        public int Id { get; set; }

        [DisplayName("Название работы")]
        public string JobTitle { get; set; } = string.Empty;

        public Dictionary<int, IServiceModel> JobServices { get; set; } = new();
    }
}
