using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
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
            using var context = new HospitalBdContext();
            var element = context.Jobs
                .Include(x => x.Doctors)
                .Include(x => x.ServicesJobs)
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Jobs.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public JobViewModel? GetElement(JobSearchModel model)
        {
            if (string.IsNullOrEmpty(model.JobTitle) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            return context.Jobs
                .Include(x => x.ServicesJobs)
                .ThenInclude(x => x.Services)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.JobTitle) && x.JobTitle == model.JobTitle) ||
                                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public List<JobViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            return context.Jobs
                    .Include(x => x.ServicesJobs)
                    .ThenInclude(x => x.Services)
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public JobViewModel? Insert(JobBindingModel model)
        {
            using var context = new HospitalBdContext();
            model.Id = context.Jobs.Count() > 0 ? context.Jobs.Max(x => x.Id) + 1 : 1;
            var newJob = Job.Create(context, model);
            if (newJob == null)
            {
                return null;
            }
            context.Jobs.Add(newJob);
            context.SaveChanges();
            return newJob.GetViewModel;
        }

        public JobViewModel? Update(JobBindingModel model)
        {
            using var context = new HospitalBdContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var job = context.Jobs.FirstOrDefault(rec => rec.Id == model.Id);
                if (job == null)
                {
                    return null;
                }
                job.Update(model);
                context.SaveChanges();
                job.UpdateServices(context, model);
                transaction.Commit();
                return job.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
