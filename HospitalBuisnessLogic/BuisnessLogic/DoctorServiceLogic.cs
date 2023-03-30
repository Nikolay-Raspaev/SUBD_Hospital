using HospitalContracts.BuisnessLogicsContracts;
using HospitalContracts.SearchModels;
using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBuisnessLogic.BuisnessLogic
{
    public class DoctorServiceLogic : IDoctorServiceLogic
    {
        private readonly IDoctorServiceStorage _doctorServiceStorage;
        public DoctorServiceLogic(IDoctorServiceStorage DoctorServiceStorage)
        {
            _doctorServiceStorage = DoctorServiceStorage;
        }

        public List<DoctorServiceViewModel>? ReadList()
        {
            var list = _doctorServiceStorage.GetFullList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

    }
}
