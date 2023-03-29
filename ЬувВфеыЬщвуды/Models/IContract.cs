using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedDataModels.Models
{
    public interface IContract : IId
    {
        DateOnly? ExerciseDate { get; }

        int ExecutionStatusId { get; }

        int PatientId { get; }

        int ContractDoctorsId { get; }

        int ContractServicesId { get; }
    }
}
