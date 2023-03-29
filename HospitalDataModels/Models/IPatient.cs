using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IPatient
    {
        public int Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public string Passport { get; set; } = null!;

        public string? TelephoneNumber { get; set; }

        public virtual List<Contract> Contracts { get; } = new List<Contract>();
    }
}
