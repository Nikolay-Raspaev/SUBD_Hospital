using Mongo.Contracts;
using Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Mongo.Database.Models;

namespace Mongo.Database.Implements
{
    public class ServiceLogic : IServiceLogic
    {

        public bool CreateService(IService model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Service>("service");
            var id = ReadList().Count == 0 ? 1 : ReadList().Max(x => x.id) + 1;
            try
            {
                var update = new Service
                {
                    id = id,
                    Name = model.Name,
                    Price = model.Price,
                };
                collection.InsertOne(update);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteService(IService model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Service>("service");
            var filter = Builders<Service>.Filter.Eq("_id", model.id);
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

        public IService? ReadElement(int id)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Service>("service");
            var filter = Builders<Service>.Filter.Eq("_id", id);
            var service = collection.Find(filter).FirstOrDefault();
            return service;
        }

        public List<Service>? ReadList()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://localhost:27017/Databases");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Service>("service");
            var filter = Builders<Service>.Filter.Empty;
            var lisrService = collection.Find(filter).ToList();
            return lisrService;
        }

        public bool UpdateService(IService model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Service>("service");       
            try
            {
                var filter = Builders<Service>.Filter.Eq("_id", model.id);
                var update = Builders<Service>.Update
                    .Set("Name", model.Name)
                    .Set("Price", model.Price);
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
