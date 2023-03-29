using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IDoctor : IId
    {
        int Id { get; }

        string Surname { get; }

        string Name { get; }

        string Patronymic { get; }

        DateOnly Birthdate { get; }

        string Passport { get; }

        string? TelephoneNumber { get; }

        string Education { get; }
    }
}
