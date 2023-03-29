using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDataModels.Models
{
    internal interface IDoctor
    {
        public int Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public string Passport { get; set; } = null!;

        public string? TelephoneNumber { get; set; }

        public string Education { get; set; } = null!;

        public int Jobid { get; set; }

        public int? AcademicRankId { get; set; }

        public virtual AcademicRank? Academicrank { get; set; }

        public virtual List<DoctorsService> Doctorsservices { get; } = new List<DoctorsService>();

        public virtual Job Job { get; set; } = null!;

        Dictionary<int, (IComponentModel, int)> DishComponents { get; }
    }
}
