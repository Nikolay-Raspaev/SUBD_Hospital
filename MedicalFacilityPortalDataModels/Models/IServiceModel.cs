

namespace MedicalFacilityPortalDataModels.Models
{
    public interface IServiceModel : IId
    {
        int Id { get; }

        string Name { get; }

        decimal Price { get; }

    }
}
