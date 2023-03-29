using MedContracts.BindingModel;
using MedContracts.SearchModels;
using MedContracts.StoragesContracts;
using MedContracts.ViewModels;
using MedDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedDataBaseImplement.Implements
{
    public class JobStorage : IJobStorage
    {
        public JobViewModel? Delete(JobBindingModel model)
        {
            using var context = new MedBdContext();
            var element = context.Jobs
                .Include(x => x.Doctors)
                .Include(x => x.Services)
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
            using var context = new MedBdContext();
            return context.Jobs
                .Include(x => x.Doctors)
                .Include(x => x.Services)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.JobTitle) && x.JobTitle == model.JobTitle) ||
                                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public List<JobViewModel> GetFilteredList(JobSearchModel model)
        {
            if (string.IsNullOrEmpty(model.JobTitle))
            {
                return new();
            }
            using var context = new MedBdContext();
            return context.Jobs
                .Include(x => x.Doctors)
                .Include(x => x.Services)
                .ThenInclude(x => x.Jobs)
                .Where(x => x.JobTitle.Contains(model.JobTitle))
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<Service> GetServiceList(JobSearchModel model)
        {
            if (string.IsNullOrEmpty(model.JobTitle))
            {
                return new();
            }
            using var context = new MedBdContext();
            Job a = context.Jobs
                .Include(x => x.Services)
                .Where(x => x.Id == model.Id).;
            return a.
        }

        public List<JobViewModel> GetFullList()
        {
            using var context = new MedBdContext();
            return context.Jobs
                .Include(x => x.Doctors)
                .Include(x => x.Services)
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public JobViewModel? Insert(JobBindingModel model)
        {
            using var context = new MedBdContext();
            model.Id = context.Jobs.Count() > 0 ? context.Jobs.Max(x => x.Id) + 1 : 1;
            var newJob = Job.Create(model);
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
            using var context = new MedBdContext();
            var component = context.Jobs.FirstOrDefault(x => x.Id == model.Id);
            if (component == null)
            {
                return null;
            }
            component.Update(model);
            context.SaveChanges();
            return component.GetViewModel;
        }
    }
}
