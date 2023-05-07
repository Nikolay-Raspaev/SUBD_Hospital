using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Models
{
    public interface IDoctor
    {
        int id { get; }

        string Surname { get; }

        string Name { get; }

        string Patronymic { get; }

        DateOnly Birthdate { get; }

        string Passport { get; }

        string TelephoneNumber { get; }

        string Education { get; }

        string JobTitle { get; }

        string AcademicRank { get; }
    }
}
