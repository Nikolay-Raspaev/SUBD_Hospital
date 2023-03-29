using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalDatabaseImplement.Models;

namespace HospitalContracts.ViewModels
{
    public class ContractViewModel : IContract
    {
        public int Id { get; }

        public DateOnly? ExerciseDate { get; }

        public int ExecutionStatusId { get; }

        public int PatientId { get; }

        public int ContractDoctorsId { get; }

        public int ContractServicesId { get; }
    }
}
