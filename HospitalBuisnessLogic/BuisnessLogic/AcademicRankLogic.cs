using HospitalBuisnessLogic.BuisnessLogicsContracts;
using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.StoragesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogic
{
    public class AcademicRankLogic : IAcademicRankLogic
    {
        private readonly IAcademicRankStorage _academicRankStorage;
        public AcademicRankLogic( IAcademicRankStorage AcademicRankStorage)
        {
            _academicRankStorage = AcademicRankStorage;
        }
        public List<AcademicRankViewModel>? ReadList(AcademicRankSearchModel? model)
        {
            var list = model == null ? _academicRankStorage.GetFullList() : _academicRankStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }
        public AcademicRankViewModel? ReadElement(AcademicRankSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _academicRankStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }
        public bool Create(AcademicRankBindingModel model)
        {
            CheckModel(model);
            if (_academicRankStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Update(AcademicRankBindingModel model)
        {
            CheckModel(model);
            if (_academicRankStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(AcademicRankBindingModel model)
        {
            CheckModel(model, false);
            if (_academicRankStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(AcademicRankBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.AcademicRankName))
            {
                throw new ArgumentNullException("Нет названия компонента",
               nameof(model.AcademicRankName));
            }
            var element = _academicRankStorage.GetElement(new AcademicRankSearchModel
            {
                AcademicRankName = model.AcademicRankName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}
