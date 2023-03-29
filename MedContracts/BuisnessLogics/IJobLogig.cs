using MedContracts.BindingModel;
using MedContracts.SearchModels;
using MedContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.BuisnessLogics
{
    public interface IJobLogig
    {
        List<JobViewModel>? ReadList(JobSearchModel? model);
        JobViewModel? ReadElement(JobSearchModel model);
        bool Create(JobBindingModel model);
        bool Update(JobBindingModel model);
        //удаляем если не с чем не связана
        bool Delete(JobBindingModel model);
    }
}
