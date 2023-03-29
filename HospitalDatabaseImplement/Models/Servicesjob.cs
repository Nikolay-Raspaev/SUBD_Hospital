using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement.Models;

public partial class ServicesJob
{
    public int Id { get; set; }

    public int ServicesId { get; set; }

    public int JobId { get; set; }

    public virtual Job Job { get; set; }

    public virtual Service Services { get; set; }
}
