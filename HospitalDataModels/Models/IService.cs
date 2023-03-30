using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    public interface IService : IId
    {

        string ServiceName { get; }

        decimal ServicePrice { get; }
    }
}
