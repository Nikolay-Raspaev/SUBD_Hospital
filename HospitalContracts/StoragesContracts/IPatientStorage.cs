using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.StoragesContracts;

public interface IPatientStorage
{
    List<PatientViewModel> GetFullList();
    PatientViewModel? GetElement(PatientSearchModel model);
    PatientViewModel? Insert(PatientBindingModel model);
    PatientViewModel? Update(PatientBindingModel model);
    PatientViewModel? Delete(PatientBindingModel model);
}

