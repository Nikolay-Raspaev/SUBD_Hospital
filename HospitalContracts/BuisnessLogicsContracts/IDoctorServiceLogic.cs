using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.BuisnessLogicsContracts;

    public interface IDoctorServiceLogic
    {
        List<DoctorServiceViewModel>? ReadList();
    }

