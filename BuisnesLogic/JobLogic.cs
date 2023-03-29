using MedContracts.BindingModel;
using MedContracts.BuisnessLogics;
using MedContracts.SearchModels;
using MedContracts.StoragesContracts;
using MedContracts.ViewModels;

namespace BuisnessLogic
{
    public class JobLogic : IJobLogig
    {
        private readonly IJobStorage _serviceStorage;

        public JobLogic(IJobStorage serviceStorage)
        {
            _serviceStorage = serviceStorage;
        }

        public bool Create(JobBindingModel model)
        {
            CheckModel(model);
            if (_serviceStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(JobBindingModel model)
        {
            CheckModel(model, false);
            if (_serviceStorage.Delete(model) == null)
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
            var element = _serviceStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }

        public List<JobViewModel>? ReadList(JobSearchModel? model)
        {
            var list = model == null ? _serviceStorage.GetFullList() : _serviceStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public bool Update(JobBindingModel model)
        {
            CheckModel(model);
            if (_serviceStorage.Update(model) == null)
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
                throw new ArgumentNullException("Нет названия профессии",
               nameof(model.JobTitle));
            }
            var element = _serviceStorage.GetElement(new JobSearchModel
            {
                Id = model.Id,
                JobTitle = model.JobTitle
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компонент с таким названием уже есть");
            }
        }
    }
}