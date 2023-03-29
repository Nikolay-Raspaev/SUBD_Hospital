using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IContract : IId
    {
        int Id { get; }

        DateOnly? ExerciseDate { get; }
    }
}
