using HospitalDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
     public class AcademicRankViewModel : AcademicRank
    {
        public int Id { get; }

        public string AcademicRankName { get; }
    }
}
