using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.Implements
{
    public class ContractStorage : IContractStorage
    {
        public ContractViewModel? Delete(ContractBindingModel model)
        {
            using var context = new HospitalBdContext();
            var element = context.Contracts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Contracts.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public ContractViewModel? GetElement(ContractSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            return context.Contracts
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Services)
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Doctors)
                .Include(x => x.Patient)
                .Include(x => x.ExecutionStatus)
                .FirstOrDefault(x => (x.Id == model.Id))
                ?.GetViewModel;
        }

        public List<ContractViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            return context.Contracts
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Services)
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Doctors)
                .Include(x => x.Patient)
                .Include(x => x.ExecutionStatus)
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public ContractViewModel? Insert(ContractBindingModel model)
        {
            using var context = new HospitalBdContext();
            model.Id = context.Contracts.Count() > 0 ? context.Contracts.Max(x => x.Id) + 1 : 1;
            var newContract = Contract.Create(model);
            if (newContract == null)
            {
                return null;
            }
            context.Contracts.Add(newContract);
            context.SaveChanges();
            return context.Contracts
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Services)
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Doctors)
                .Include(x => x.Patient)
                .Include(x => x.ExecutionStatus)
                .FirstOrDefault(x => (x.Id == model.Id))
                ?.GetViewModel;
        }

        public ContractViewModel? Update(ContractBindingModel model)
        {
            using var context = new HospitalBdContext();
            var contracts = context.Contracts
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Services)
                .Include(x => x.ContractNavigation)
                .ThenInclude(x => x.Doctors)
                .Include(x => x.Patient)
                .Include(x => x.ExecutionStatus)
                .FirstOrDefault(x => (x.Id == model.Id));
            if (contracts == null)
            {
                return null;
            }
            contracts.Update(model);
            context.SaveChanges();
            return contracts.GetViewModel;
        }
    }
}
