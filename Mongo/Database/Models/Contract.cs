﻿using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Database.Models
{
    public class Contract : IContract
    {
        public int id { get; set; }
        public DateTime? ExerciseDate { get; set; }
        public string Status { get; set; }
        public IPatient Patient { get; set; }
        public string PatientName { get; set; }
        public IDoctor Doctor { get; set; }
        public string DoctorName { get; set; }
        public int ServiceId { get; set; }
    }
}
