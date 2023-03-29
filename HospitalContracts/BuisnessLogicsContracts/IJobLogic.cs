using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.BuisnessLogicsContracts;

public interface IJobLogic
    {
        List<JobViewModel>? ReadList(JobSearchModel? model);
        JobViewModel? ReadElement(JobSearchModel model);
        bool Create(JobBindingModel model);
        bool Update(JobBindingModel model);
        bool Delete(JobBindingModel model);
    }

