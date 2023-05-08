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
    public class MongoJobLogic : IMongoJobLogic
    {

        public bool CreateJob(IJob model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Job>("job");
            var filter = Builders<Job>.Filter.Eq(a => a.id, model.id);
            var id = ReadList().Count == 0 ? 1 : ReadList().Max(x => x.id) + 1;
            try
            {
                var update = new Job
                {
                    id = id,
                    jobTitle = model.jobTitle,
                };
                collection.InsertOne(update);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteJob(IJob model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Job>("job");
            var filter = Builders<Job>.Filter.Eq(a => a.id, model.id);
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
        public bool DeleteAllJob()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Job>("job");
            var filter = Builders<Job>.Filter.Empty;
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

        public IJob? ReadElement(int id)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Job> ("job");
            var filter = Builders<Job>.Filter.Eq(a => a.id, id);
            var job = collection.Find(filter).FirstOrDefault();
            return job;
        }

        public List<Job>? ReadList()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://localhost:27017/Databases");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Job>("job");
            var filter = Builders<Job>.Filter.Empty;
            var listJob = collection.Find(filter).ToList();
            return listJob;
        }

        public bool UpdateJob(IJob model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");
            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<Job>("job");       
            try
            {
                var filter = Builders<Job>.Filter.Eq(a => a.id, model.id);
                var update = Builders<Job>.Update.Set("jobTitle", model.jobTitle);
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
