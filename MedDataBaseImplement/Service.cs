using System;
using System.Collections.Generic;

namespace MedDataBaseImplement;

public partial class Service
{
    public int Id { get; set; }

    public string ServicesName { get; set; } = null!;

    public decimal ServicesPrice { get; set; }

    public virtual ICollection<Doctorsservice> DoctorsServices { get; } = new List<Doctorsservice>();

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();
}
