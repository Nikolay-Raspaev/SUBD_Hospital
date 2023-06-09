﻿using HospitalContracts.BindingModels;
using HospitalContracts.SearchModels;
using HospitalContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.StoragesContracts;

public interface IServiceStorage
{
    List<ServiceViewModel> GetFullList();
    List<ServiceViewModel> GetFilteredList(int model);
    ServiceViewModel? GetElement(ServiceSearchModel model);
    ServiceViewModel? Insert(ServiceBindingModel model);
    ServiceViewModel? Update(ServiceBindingModel model);
    ServiceViewModel? Delete(ServiceBindingModel model);
}

