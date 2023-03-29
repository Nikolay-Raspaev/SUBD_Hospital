using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IService : IId
    {
        int Id { get; }

        string ServicesName { get; }

        decimal ServicesPrice { get; }
    }
}
