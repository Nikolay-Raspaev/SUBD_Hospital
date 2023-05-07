using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Models
{
    public interface INoUserContract
    {
        int id { get; }
        DateTime? ExerciseDate { get; }
        string Status { get; }
        IDoctor Doctor { get; }
        string DoctorName { get; }
        int ServiceId { get; }
    }
}
