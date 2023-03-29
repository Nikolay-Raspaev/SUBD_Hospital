using MedicalFacilityPortalContracts.BindingModels;
using MedicalFacilityPortalContracts.ViewModels;
using MedicalFacilityPortalDataModels.Enums;
using System;
using System.Collections.Generic;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class Job
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public virtual List<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual List<Servicesjob> ServicesJobs { get; } = new List<Servicesjob>();

    public static Job Create(MedDB context, JobBindingModel model)
    {
        return new Job()
        {
            Id = model.Id,
            JobTitle = model.JobTitle,
        };
    }
    //при обнофлении с изменением должности нужно удалять старую ссылку в связи с работой

    public void Update(JobBindingModel model)
    {
        if (model == null)
        {
            return;
        }
        JobTitle = model.JobTitle;
    }

    public JobViewModel GetViewModel => new()
    {
        JobTitle = JobTitle,
    };
}
