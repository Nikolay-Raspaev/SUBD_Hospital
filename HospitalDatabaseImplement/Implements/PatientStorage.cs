using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using HospitalDatabaseImplement.StoragesContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.Implements
{
    public class PatientStorage : IPatientStorage
    {
        public PatientViewModel? Delete(PatientBindingModel model)
        {
            using var context = new HospitalBdContext();
            var element = context.Patients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Patients.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public PatientViewModel? GetElement(PatientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Passport) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            return context.Patients
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.Passport) && x.Passport == model.Passport) ||
                    (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }


        public List<PatientViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            return context.Patients
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<Patient> GetFullListPatient()
        {
            using var context = new HospitalBdContext();
            return context.Patients
                .Include(x => x.Contracts)
                .ThenInclude(x => x.ContractNavigation)
                .ThenInclude(x => x.Doctors)
                .ThenInclude(x => x.Job)
                .Include(x => x.Contracts)
                .ThenInclude(x => x.ContractNavigation)
                .ThenInclude(x => x.Doctors)
                .ThenInclude(x => x.AcademicRank)
                .Include(x => x.Contracts)
                .ThenInclude(x => x.ExecutionStatus)
                .ToList();
        }

        public PatientViewModel? Insert(PatientBindingModel model)
        {
            using var context = new HospitalBdContext();
            model.Id = context.Patients.Count() > 0 ? context.Patients.Max(x => x.Id) + 1 : 1;
            var newPatient = Patient.Create(model);
            if (newPatient == null)
            {
                return null;
            }

            context.Patients.Add(newPatient);
            context.SaveChanges();
            return newPatient.GetViewModel;
        }

        public PatientViewModel? Update(PatientBindingModel model)
        {
            using var context = new HospitalBdContext();
            var patient = context.Patients.FirstOrDefault(x => x.Id == model.Id);
            if (patient == null)
            {
                return null;
            }
            patient.Update(model);
            context.SaveChanges();
            return patient.GetViewModel;
        }
    }
}
