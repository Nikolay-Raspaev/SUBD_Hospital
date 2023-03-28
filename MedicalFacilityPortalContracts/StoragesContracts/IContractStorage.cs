using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalContracts.StoragesContracts
{
    public interface IContractStorage
    {
        List<ContractViewModel> GetFullList();
        List<ContractViewModel> GetFilteredList(ContractSearchModel model);
        ContractViewModel? GetElement(ContractSearchModel model);
        ContractViewModel? Insert(ContractBindingModel model);
        ContractViewModel? Update(ContractBindingModel model);
        ContractViewModel? Delete(ContractBindingModel model);
    }
}
