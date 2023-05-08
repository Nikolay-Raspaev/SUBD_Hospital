using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogicsContracts;

public interface IDoctorLogic
    {
        List<DoctorViewModel>? ReadList(DoctorSearchModel? model);
        DoctorViewModel? ReadElement(DoctorSearchModel model);
        bool Create(DoctorBindingModel model);
        bool Update(DoctorBindingModel model);
        bool Delete(DoctorBindingModel model);
    }

