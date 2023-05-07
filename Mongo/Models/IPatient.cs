using Mongo.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Models
{
    public interface IPatient
    {
        int id { get; }

        string Surname { get; }

        string Name { get; }

        string Patronymic { get; }

        DateTime? Birthdate { get; }

        string Passport { get; }

        string TelephoneNumber { get; }

        public List<INoUserContract> PatientContracts { get; set; }
        public List<Contract> PatientContract { get; set; }
    }
}
