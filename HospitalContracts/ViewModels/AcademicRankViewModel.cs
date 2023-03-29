using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
     public class AcademicRankViewModel : IAcademicRank
     {
        public int Id { get; set; }

        [DisplayName("Название учёной степени")]
        public string AcademicRankName { get; set; } = string.Empty;
    }
}
