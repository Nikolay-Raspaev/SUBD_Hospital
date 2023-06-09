﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Models
{
    public interface IContract
    {
        int id { get; }
        DateTime? ExerciseDate { get; }
        string Status { get; }
        IPatient Patient { get; }
        string PatientName { get; set; }
        IDoctor Doctor { get; }
        string DoctorName { get; set; }
        int ServiceId { get; }
    }
}
