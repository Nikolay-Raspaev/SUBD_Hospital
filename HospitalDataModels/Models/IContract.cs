using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IContract
    {
        public int Id { get; set; }

        public DateOnly? ExerciseDate { get; set; }

        public int ExecutionStatusId { get; set; }

        public int PatientId { get; set; }

        public int ContractDoctorsId { get; set; }

        public int ContractServicesId { get; set; }

        public virtual DoctorsService ContractNavigation { get; set; } = null!;

        public virtual ExecutionStatus ExecutionStatus { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
    }
}
