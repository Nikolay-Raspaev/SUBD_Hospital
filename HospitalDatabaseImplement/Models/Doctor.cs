using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalDatabaseImplement.Models;

public partial class Doctor : IDoctor
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

    public virtual List<DoctorsService> DoctorsServices { get; } = new List<DoctorsService>();

    public virtual Job Job { get; set; } = null!;

    public Dictionary<int, IService> _doctorServices = null;

    [NotMapped]
    public Dictionary<int, IService> DoctorServices
    {
        get
        {
            if (_doctorServices == null)
            {
                _doctorServices = Services.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component as IComponentModel, recPC.Count));
            }
            return _doctorServices;
        }
    }
}
