using Mongo.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Mongo.Database.Models;
using Mongo.Contracts;
using System.Xml.Linq;
using MongoDB.Bson.Serialization;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Serializers;

namespace Mongo.Database.Implements
{
    public class PatientLogic : IPatientLogic
    {
        
        public IPatient CreatePatient(IPatient model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Patient>("patient");
            var id = ReadList().Count == 0 ? 1 : ReadList().Max(x => x.id) + 1;
            try
            {
                var update = new Patient
                {
                    id = id,
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Birthdate = model.Birthdate,
                    Passport = model.Passport,
                    TelephoneNumber = model.TelephoneNumber,
                    PatientContracts = model.PatientContracts,
                    PatientContract = model.PatientContract
                };
                collection.InsertOne(update);
                return update;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeletePatient(IPatient model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Patient>("patient");
            var filter = Builders<Patient>.Filter.Eq("_id", model.id);
            try
            {
                collection.DeleteOne(filter);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IPatient? ReadElement(int id)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Patient>("patient");
            var filter = Builders<Patient>.Filter.Eq("_id", id);
            var patient = collection.Find(filter).FirstOrDefault();
            return patient;
        }

        public List<Patient>? ReadList()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://localhost:27017/Databases");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Patient>("patient");
            var filter = Builders<Patient>.Filter.Empty;
            var listPatient = collection.Find(filter).ToList();
            return listPatient;
        }

        public bool UpdatePatient(IPatient model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Patient>("patient");
            try
            {
                var filter = Builders<Patient>.Filter.Eq("_id", model.id);
                var update = Builders<Patient>.Update
                    .Set("Patronymic", model.Patronymic)
                    .Set("Surname", model.Surname)
                    .Set("Name", model.Name)
                    .Set("Patronymic", model.Patronymic)
                    .Set("Birthdate", model.Birthdate)
                    .Set("Passport", model.Passport)
                    .Set("TelephoneNumber", model.TelephoneNumber)
                    .Set("PatientContracts", model.PatientContracts)
                    .Set("PatientContract", model.PatientContract);
                collection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
