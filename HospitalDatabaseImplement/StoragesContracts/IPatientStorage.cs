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

public interface IPatientStorage
{
    List<PatientViewModel> GetFullList();
    List<Patient> GetFullListPatient();
    PatientViewModel? GetElement(PatientSearchModel model);
    PatientViewModel? Insert(PatientBindingModel model);
    PatientViewModel? Update(PatientBindingModel model);
    PatientViewModel? Delete(PatientBindingModel model);
}

