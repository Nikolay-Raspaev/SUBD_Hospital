using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement;

public partial class Service
{
    public int Id { get; set; }

    public string Servicesname { get; set; } = null!;

    public decimal Servicesprice { get; set; }

    public virtual ICollection<Doctorsservice> Doctorsservices { get; } = new List<Doctorsservice>();

    public virtual ICollection<Servicesjob> Servicesjobs { get; } = new List<Servicesjob>();
}
