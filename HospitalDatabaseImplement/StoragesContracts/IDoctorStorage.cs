using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using HospitalDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.StoragesContracts;

public interface IDoctorStorage
{
    List<DoctorViewModel> GetFullList();
    List<Doctor> GetFullListDoctor();
    DoctorViewModel? GetElement(DoctorSearchModel model);
    DoctorViewModel? Insert(DoctorBindingModel model);
    DoctorViewModel? Update(DoctorBindingModel model);
    DoctorViewModel? Delete(DoctorBindingModel model);
}

