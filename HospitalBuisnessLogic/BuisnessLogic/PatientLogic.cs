using HospitalContracts.BindingModels;
using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogic
{
    public class PatientLogic : IPatientLogic
    {
        private readonly IPatientStorage _patientStorage;
        public PatientLogic(IPatientStorage PatientStorage)
        {
            _patientStorage = PatientStorage;
        }
        public List<PatientViewModel>? ReadList(PatientSearchModel? model)
        {
            var list = _patientStorage.GetFullList();
            if (list == null)
            {
                return null;
            }
            return list;
        }
        public PatientViewModel? ReadElement(PatientSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _patientStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }
        public bool Create(PatientBindingModel model)
        {
            CheckModel(model);
            if (_patientStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Update(PatientBindingModel model)
        {
            CheckModel(model);
            if (_patientStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(PatientBindingModel model)
        {
            CheckModel(model, false);
            if (_patientStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(PatientBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            var element = _patientStorage.GetElement(new PatientSearchModel
            {
                Passport = model.Passport
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}
