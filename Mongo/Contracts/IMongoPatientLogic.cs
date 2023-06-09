﻿using Mongo.Database.Models;
using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Contracts
{
    public interface IMongoPatientLogic
    {
        List<Patient>? ReadList();
        IPatient? ReadElement(int id);
        IPatient CreatePatient(IPatient model);
        bool DeletePatient(IPatient model);
        bool DeleteAllPatient();
        bool UpdatePatient(IPatient model);
    }
}
