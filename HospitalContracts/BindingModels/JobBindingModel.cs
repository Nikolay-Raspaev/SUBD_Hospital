using HospitalDataModels.Models;
using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class JobBindingModel : IJob
{
    public int Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public Dictionary<int, IService> JobServices { get; set; } = new();
}
