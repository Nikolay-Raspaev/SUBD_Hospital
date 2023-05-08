using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using HospitalDatabaseImplement.StoragesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.Implements
{
    public class ExecutionStatusStorage : IExecutionStatusStorage
    {
        public ExecutionStatusViewModel? Delete(ExecutionStatusBindingModel model)
        {
            using var context = new HospitalBdContext();
            var element = context.ExecutionStatuses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.ExecutionStatuses.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ExecutionStatusViewModel? GetElement(ExecutionStatusSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ExecutionStatusName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            return context.ExecutionStatuses
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ExecutionStatusName) && x.ExecutionStatusName == model.ExecutionStatusName) ||
                    (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public List<ExecutionStatusViewModel> GetFilteredList(ExecutionStatusSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ExecutionStatusName))
            {
                return new();
            }
            using var context = new HospitalBdContext();
            return context.ExecutionStatuses
                    .Where(x => x.ExecutionStatusName.Contains(model.ExecutionStatusName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<ExecutionStatusViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            return context.ExecutionStatuses
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public ExecutionStatusViewModel? Insert(ExecutionStatusBindingModel model)
        {
            using var context = new HospitalBdContext();
            model.Id = context.ExecutionStatuses.Count() > 0 ? context.ExecutionStatuses.Max(x => x.Id) + 1 : 1;
            var newExecutionStatus = ExecutionStatus.Create(model);
            if (newExecutionStatus == null)
            {
                return null;
            }
            context.ExecutionStatuses.Add(newExecutionStatus);
            context.SaveChanges();
            return newExecutionStatus.GetViewModel;
        }

        public ExecutionStatusViewModel? Update(ExecutionStatusBindingModel model)
        {
            using var context = new HospitalBdContext();
            var executionStatus = context.ExecutionStatuses.FirstOrDefault(x => x.Id == model.Id);
            if (executionStatus == null)
            {
                return null;
            }
            executionStatus.Update(model);
            context.SaveChanges();
            return executionStatus.GetViewModel;
        }
    }
}
