using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;

namespace MedicalFacilityPortalContracts.BusinessLogicsContracts
{
    public interface IContractLogic
    {
        //чтение листа, если модель есть то с фильтром, если модели нет то весь
        // знак вопроса так как модет вернуть null, а в качестве параметра, так как модель может не передаваться
        List<ContractViewModel>? ReadList(ContractSearchModel? model);
        ContractViewModel? ReadElement(ContractSearchModel model);
        bool Create(ContractBindingModel model);
        //Удаляем если контракт ещё не исполнен(не оплачен)
        bool Delete(ContractBindingModel model);
        bool TakeOrderInWork(ContractBindingModel model);
        bool FinishOrder(ContractBindingModel model);
    }
}
