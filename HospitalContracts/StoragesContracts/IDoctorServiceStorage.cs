using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.StoragesContracts
{
    public interface IDoctorServiceStorage
    {
        List<DoctorServiceViewModel> GetFullList();
    }
}