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
    public class DoctorStorage : IDoctorStorage
    {
        public List<DoctorViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            return context.Doctors
                    .Include(x => x.DoctorsServices )
                    .ThenInclude(x => x.Services)
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public DoctorViewModel? GetElement(DoctorSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Passport) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            return context.Doctors
                .Include(x => x.DoctorsServices)
                .ThenInclude(x => x.Services)
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.Passport) && x.Passport == model.Passport) ||
                                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public DoctorViewModel? Insert(DoctorBindingModel model)
        {
            using var context = new HospitalBdContext();
            var newDoctor = Doctor.Create(context, model);
            if (newDoctor == null)
            {
                return null;
            }
            context.Doctors.Add(newDoctor);
            context.SaveChanges();
            return newDoctor.GetViewModel;
        }

        public DoctorViewModel? Update(DoctorBindingModel model)
        {
            using var context = new HospitalBdContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var doctor = context.Doctors.FirstOrDefault(rec => rec.Id == model.Id);
                if (doctor == null)
                {
                    return null;
                }
                doctor.Update(model);
                context.SaveChanges();
                doctor.UpdateServices(context, model);
                transaction.Commit();
                return doctor.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public DoctorViewModel? Delete(DoctorBindingModel model)
        {
            using var context = new HospitalBdContext();
            var element = context.Doctors
                .Include(x => x.DoctorsServices)
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Doctors.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
