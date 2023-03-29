using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IContract
    {
        int Id { get; }

        DateOnly? ExerciseDate { get; }

        int ExecutionStatusId { get; }

        int PatientId { get; }

        int ContractDoctorsId { get; }

        int ContractServicesId { get; }
    }
}
