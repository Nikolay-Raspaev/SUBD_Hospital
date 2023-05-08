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
    public class MongoDoctorLogic : IMongoDoctorLogic
    {
        
        public IDoctor CreateDoctor(IDoctor model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Doctor>("doctor");
            var id = ReadList().Count == 0 ? 1 : ReadList().Max(x => x.id) + 1;
            try
            {
                var update = new Doctor
                {
                    id = id,
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Birthdate = model.Birthdate,
                    Passport = model.Passport,
                    TelephoneNumber = model.TelephoneNumber,
                    Education = model.Education,
                    JobTitle = model.JobTitle,
                    AcademicRank = model.AcademicRank,
                    DoctorServices = model.DoctorServices
                };
                collection.InsertOne(update);
                return update;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteDoctor(IDoctor model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Doctor>("doctor");
            var filter = Builders<Doctor>.Filter.Eq("_id", model.id);
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

        public bool DeleteAllDoctor()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Doctor>("doctor");
            var filter = Builders<Doctor>.Filter.Empty;
            try
            {
                collection.DeleteMany(filter);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IDoctor? ReadElement(int id)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Doctor>("doctor");
            var filter = Builders<Doctor>.Filter.Eq("_id", id);
            var doctor = collection.Find(filter).FirstOrDefault();
            return doctor;
        }

        public List<Doctor>? ReadList()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://localhost:27017/Databases");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Doctor>("doctor");
            var filter = Builders<Doctor>.Filter.Empty;
            var listDoctor = collection.Find(filter).ToList();
            return listDoctor;
        }

        public bool UpdateDoctor(IDoctor model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Doctor>("doctor");
            try
            {
                var filter = Builders<Doctor>.Filter.Eq("_id", model.id);
                var update = Builders<Doctor>.Update      
                    .Set("Patronymic", model.Patronymic)
                    .Set("Surname", model.Surname)
                    .Set("Name", model.Name)
                    .Set("Patronymic", model.Patronymic)
                    .Set("Birthdate", model.Birthdate)
                    .Set("Passport", model.Passport)
                    .Set("TelephoneNumber", model.TelephoneNumber)
                    .Set("Education", model.Education)
                    .Set("JobTitle", model.JobTitle)
                    .Set("AcademicRank", model.AcademicRank)
                    .Set("DoctorServices", model.DoctorServices);
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
