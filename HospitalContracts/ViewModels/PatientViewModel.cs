using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalContracts.ViewModels
{
    public class PatientViewModel : IPatient
    {
        public int Id { get; }

        public string Surname { get; }

        public string Name { get; }

        public string Patronymic { get; }

        public DateOnly Birthdate { get; }

        public string Passport { get; }

        public string? TelephoneNumber { get; }
    }
}
