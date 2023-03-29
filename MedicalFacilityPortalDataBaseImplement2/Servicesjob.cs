using System;
using System.Collections.Generic;

namespace MedicalFacilityPortalDataBaseImplement2;

public partial class Servicesjob
{
    public int Id { get; set; }

    public int ServicesId { get; set; }

    public int JobId { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Service Services { get; set; } = null!;
}
