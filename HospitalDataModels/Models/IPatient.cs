using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IPatient
    {
        int Id { get; }

        string Surname { get; }

        string Name { get; }

        string Patronymic { get; }

        DateOnly Birthdate { get; }

        string Passport { get; }

        string? TelephoneNumber { get; }
    }
}
