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
    public class AcademicRankLogic : IAcademicRankLogic
    {
        private readonly IAcademicRankStorage _academicRankStorage;
        public AcademicRankLogic( IAcademicRankStorage AcademicRankStorage)
        {
            _academicRankStorage = AcademicRankStorage;
        }
        public List<AcademicRankViewModel>? ReadList(AcademicRankSearchModel? model)
        {
            _logger.LogInformation("ReadList. AcademicRankName:{AcademicRankName}. Id:{Id}", model?.AcademicRankName, model?.Id);
            var list = model == null ? _academicRankStorage.GetFullList() : _academicRankStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public AcademicRankViewModel? ReadElement(AcademicRankSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. AcademicRankName:{AcademicRankName}. Id:{Id}", model.AcademicRankName, model.Id);
            var element = _academicRankStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(AcademicRankBindingModel model)
        {
            CheckModel(model);
            if (_academicRankStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(AcademicRankBindingModel model)
        {
            CheckModel(model);
            if (_academicRankStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(AcademicRankBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_academicRankStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
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
            if (model.Cost <= 0)
            {
                throw new ArgumentNullException("Цена компонента должна быть больше 0", nameof(model.Cost));
            }
            _logger.LogInformation("AcademicRank. AcademicRankName:{AcademicRankName}. Cost:{ Cost}. Id:{Id}", model.AcademicRankName, model.Cost, model.Id);
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
