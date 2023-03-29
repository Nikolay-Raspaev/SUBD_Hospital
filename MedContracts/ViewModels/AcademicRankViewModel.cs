using MedDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedContracts.ViewModels
{
    public class AcademicRankViewModel : IAcademicRank
    {
        [DisplayName("Название учёной степени")]
        public string AcademicRankName { get; set; } = string.Empty;

        public int Id { get; set; }
    }
}
