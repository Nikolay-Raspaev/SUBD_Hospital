﻿using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.BuisnessLogicsContracts;

public interface IPatientLogic
    {
        List<PatientViewModel>? ReadList(PatientSearchModel? model);
        PatientViewModel? ReadElement(PatientSearchModel model);
        bool Create(PatientBindingModel model);
        bool Update(PatientBindingModel model);
        bool Delete(PatientBindingModel model);
    }

