using MedicalFacilityPortalContracts.SearchModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalContracts.BindingModels;

namespace MedicalFacilityPortalContracts.BusinessLogicsContracts
{
    public interface IPatientLogic
    {
        //чтение листа, если модель есть то с фильтром, если модели нет то весь
        // знак вопроса так как модет вернуть null, а в качестве параметра, так как модель может не передаваться
        List<PatientViewModel>? ReadList(PatientSearchModel? model);
        PatientViewModel? ReadElement(PatientSearchModel model);
        bool Create(PatientBindingModel model);
        bool Update(PatientBindingModel model);
        //Удаляем только если у данного клиента нет никаких контрактов с мед. учреждением
        bool Delete(PatientBindingModel model);
    }
}
