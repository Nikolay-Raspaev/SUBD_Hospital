using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogicsContracts;

    public interface IAcademicRankLogic
    {
        List<AcademicRankViewModel>? ReadList(AcademicRankSearchModel? model);
        AcademicRankViewModel? ReadElement(AcademicRankSearchModel model);
        bool Create(AcademicRankBindingModel model);
        bool Update(AcademicRankBindingModel model);
        bool Delete(AcademicRankBindingModel model);
    }

