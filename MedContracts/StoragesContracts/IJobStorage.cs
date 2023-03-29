using MedContracts.BindingModel;
using MedContracts.SearchModels;
using MedContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.StoragesContracts
{
    public interface IJobStorage
    {
        List<JobViewModel> GetFullList();
        List<JobViewModel> GetFilteredList(JobSearchModel model);
        JobViewModel? GetElement(JobSearchModel model);
        JobViewModel? Insert(JobBindingModel model);
        JobViewModel? Update(JobBindingModel model);
        JobViewModel? Delete(JobBindingModel model);
    }
}
