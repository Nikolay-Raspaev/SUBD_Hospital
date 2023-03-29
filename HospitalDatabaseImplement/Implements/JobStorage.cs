using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.Implements
{
    public class JobStorage : IJobStorage
    {
        public JobViewModel? Delete(JobBindingModel model)
        {
            throw new NotImplementedException();
        }

        public JobViewModel? GetElement(JobSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<JobViewModel> GetFilteredList(JobSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<JobViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public JobViewModel? Insert(JobBindingModel model)
        {
            throw new NotImplementedException();
        }

        public JobViewModel? Update(JobBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
