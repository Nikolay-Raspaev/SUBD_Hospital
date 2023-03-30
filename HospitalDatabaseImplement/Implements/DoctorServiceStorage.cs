using HospitalContracts.StoragesContracts;
using HospitalContracts.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDatabaseImplement.Implements
{
    public class DoctorServiceStorage : IDoctorServiceStorage
    {
        public List<DoctorServiceViewModel> GetFullList()
        {
            using var context = new HospitalBdContext();
            var list = context.DoctorsServices
                .Include(x => x.Doctors)
                .Include(x => x.Services)
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
            return list;

        }
    }
}
