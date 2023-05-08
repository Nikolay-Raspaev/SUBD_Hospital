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
    public class AcademicRankStorage : IAcademicRankStorage
    {
        public AcademicRankViewModel? Delete(AcademicRankBindingModel model)
        {
            using var context = new HospitalBdContext();
            var element = context.AcademicRanks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.AcademicRanks.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public AcademicRankViewModel? GetElement(AcademicRankSearchModel model)
        {
            if (string.IsNullOrEmpty(model.AcademicRankName) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new HospitalBdContext();
            return context.AcademicRanks
                    .FirstOrDefault(x => (!string.IsNullOrEmpty(model.AcademicRankName) && x.AcademicRankName == model.AcademicRankName) ||
                    (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public List<AcademicRankViewModel> GetFilteredList(AcademicRankSearchModel model)
        {
            if (string.IsNullOrEmpty(model.AcademicRankName))
            {
                return new();
            }
            using var context = new HospitalBdContext();
            return context.AcademicRanks
                    .Where(x => x.AcademicRankName.Contains(model.AcademicRankName))
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<AcademicRankViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            return context.AcademicRanks
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public AcademicRankViewModel? Insert(AcademicRankBindingModel model)
        {
            using var context = new HospitalBdContext();
            model.Id = context.AcademicRanks.Count() > 0 ? context.AcademicRanks.Max(x => x.Id) + 1 : 1;
            var newAcademicRank = AcademicRank.Create(model);
            if (newAcademicRank == null)
            {
                return null;
            }
            context.AcademicRanks.Add(newAcademicRank);
            context.SaveChanges();
            return newAcademicRank.GetViewModel;
        }

        public AcademicRankViewModel? Update(AcademicRankBindingModel model)
        {
            using var context = new HospitalBdContext();
            var academicRank = context.AcademicRanks.FirstOrDefault(x => x.Id == model.Id);
            if (academicRank == null)
            {
                return null;
            }
            academicRank.Update(model);
            context.SaveChanges();
            return academicRank.GetViewModel;
        }
    }
}
