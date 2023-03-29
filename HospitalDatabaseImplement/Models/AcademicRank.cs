using HospitalDataModels.Models;
using System;
using System.Collections.Generic;
using HospitalContracts.BindingModels;
using HospitalContracts.ViewModels;

namespace HospitalDatabaseImplement.Models;

public partial class AcademicRank : IAcademicRank
{
    public int Id { get; set; }

    public string AcademicRankName { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public static AcademicRank? Create(AcademicRankBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return new AcademicRank()
        {
            Id = model.Id,
            AcademicRankName = model.AcademicRankName,
        };
    }

    public static AcademicRank Create(AcademicRankViewModel model)
    {
        return new AcademicRank
        {
            Id = model.Id,
            AcademicRankName = model.AcademicRankName,
        };
    }

    public void Update(AcademicRankBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        AcademicRankName = model.AcademicRankName;
    }

    public AcademicRankViewModel GetViewModel => new()
    {
        Id = Id,
        AcademicRankName = AcademicRankName
    };
}
