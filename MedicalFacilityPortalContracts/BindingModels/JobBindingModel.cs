using MedicalFacilityPortalDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalFacilityPortalContracts.BindingModels
{
    public class JobBindingModel : IJobModel
    {
        public int Id { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public Dictionary<int, IServiceModel> JobServices { get; set; } = new();
    }
}
