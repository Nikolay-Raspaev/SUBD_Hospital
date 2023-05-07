using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Database.Models
{
    public class Patient : IPatient
    {
        public int id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Passport { get; set; }

        public string TelephoneNumber { get; set; }

        public List<INoUserContract> PatientContracts { get; set; }
    }
}
