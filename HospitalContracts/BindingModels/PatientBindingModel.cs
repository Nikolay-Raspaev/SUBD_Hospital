using HospitalDataModels.Models;
using System;
using System.Collections.Generic;

namespace HospitalContracts.BindingModels;

public class PatientBindingModel : IPatient
    {
        public int Id { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public string Passport { get; set; } = null!;

        public string? TelephoneNumber { get; set; }

    }
