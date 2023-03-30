using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    public interface IDoctorService
    {
        int DoctorsId { get; }

        int ServicesId { get; }
    }
}
