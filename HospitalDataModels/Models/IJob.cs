using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IJob : IId
    {
        int Id { get; }

        string JobTitle { get; }
    }
}
