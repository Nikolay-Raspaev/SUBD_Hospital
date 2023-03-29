using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.StoragesContracts;

public interface IAcademicRankStorage
{
    List<AcademicRankViewModel> GetFullList();
    List<AcademicRankViewModel> GetFilteredList(AcademicRankSearchModel model);
    AcademicRankViewModel? GetElement(AcademicRankSearchModel model);
    AcademicRankViewModel? Insert(AcademicRankBindingModel model);
    AcademicRankViewModel? Update(AcademicRankBindingModel model);
    AcademicRankViewModel? Delete(AcademicRankBindingModel model);
}

