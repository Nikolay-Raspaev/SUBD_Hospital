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
    public class JobLogic : IJobLogic
    {
        private readonly IJobStorage _jobStorage;
        public JobLogic(IJobStorage jobStorage)
        {
            _jobStorage = jobStorage;
        }

        public bool Create(JobBindingModel model)
        {
            CheckModel(model);
            if (_jobStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(JobBindingModel model)
        {
            CheckModel(model, false);
            if (_jobStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }

        public JobViewModel? ReadElement(JobSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _jobStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }

        public List<JobViewModel>? ReadList(JobSearchModel? model)
        {
            var list = _jobStorage.GetFullList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public bool Update(JobBindingModel model)
        {
            CheckModel(model);
            if (_jobStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(JobBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.JobTitle))
            {
                throw new ArgumentNullException("Нет названия компонента", nameof(model.JobTitle));
            }
            var element = _jobStorage.GetElement(new JobSearchModel
            {
                JobTitle = model.JobTitle
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Продукт с таким названием уже есть");
            }
        }
    }
}
