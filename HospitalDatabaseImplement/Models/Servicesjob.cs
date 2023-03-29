using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class Servicesjob
{
    public int Id { get; set; }

    public int? Servicesid { get; set; }

    public int? Jobid { get; set; }

    public virtual Job? Job { get; set; }

    public virtual Service? Services { get; set; }
}
