using System;
using System.Collections.Generic;

namespace HospitalDatabaseImplement;

public partial class Executionstatus
{
    public int Id { get; set; }

    public string Executionstatus1 { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();
}
