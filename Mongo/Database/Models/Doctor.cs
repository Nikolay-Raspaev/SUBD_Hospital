using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Database.Models
{
    public class Doctor : IDoctor
    {
        public int id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Passport { get; set; }

        public string TelephoneNumber { get; set; }

        public string Education { get; set; }

        public string JobTitle { get; set; }

        public string AcademicRank { get; set; }

        public List<IService> DoctorServices { get; set; }
    }
}
