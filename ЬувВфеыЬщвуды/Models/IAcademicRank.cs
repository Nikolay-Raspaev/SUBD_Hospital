using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedDataModels.Models
{
    public interface IAcademicRank : IId
    {
        public string AcademicRankName { get; }
    }
}
