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
    public class MongoContractLogic : IMongoContractLogic
    {
        
        public IContract CreateContract(IContract model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Contract>("contract");
            var id = 0;
            if (model.id == 0) id = ReadList().Count == 0 ? 1 : ReadList().Max(x => x.id) + 1;
            else id = model.id;
            try
            {
                var update = new Contract
                {
                    id = id,
                    ExerciseDate = model.ExerciseDate,
                    Status = model.Status,
                    Patient = model.Patient,
                    PatientName = model.Patient.Name,
                    Doctor = model.Doctor,
                    DoctorName = model.Doctor.Name,
                    ServiceId = model.ServiceId,
                };
                collection.InsertOne(update);
                return update;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteAllContract()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Contract>("contract");
            var filter = Builders<Contract>.Filter.Empty;
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

        public bool DeleteContract(IContract model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Contract>("contract");
            var filter = Builders<Contract>.Filter.Eq("_id", model.id);
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

        public IContract? ReadElement(int id)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Contract>("contract");
            var filter = Builders<Contract>.Filter.Eq("_id", id);
            var contract = collection.Find(filter).FirstOrDefault();
            return contract;
        }

        public List<Contract>? ReadList()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://localhost:27017/Databases");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Contract>("contract");
            var filter = Builders<Contract>.Filter.Empty;
            var listContract = collection.Find(filter).ToList();
            return listContract;
        }

        public bool UpdateContract(IContract model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Contract>("contract");
            try
            {
                var filter = Builders<Contract>.Filter.Eq("_id", model.id);
                var update = Builders<Contract>.Update
                    .Set("Status", model.Status)
                    .Set("ExerciseDate", model.ExerciseDate);
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
