using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.StoragesContracts;

public interface IJobStorage
{
    List<JobViewModel> GetFullList();
    JobViewModel? GetElement(JobSearchModel model);
    JobViewModel? Insert(JobBindingModel model);
    JobViewModel? Update(JobBindingModel model);
    JobViewModel? Delete(JobBindingModel model);
}

