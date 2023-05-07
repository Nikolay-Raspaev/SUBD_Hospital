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
    public class JobLogic : IJobLogic
    {

        public bool CreateJob(IJob model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<BsonDocument>("job");

            try
            {
                var update = new BsonDocument
                {
                    {"_id", model.id+1},
                    { "jobTitle", model.jobTitle},
                    //{ "BlockingId", model.blockingId?.ToString()}
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
            var collection = database.GetCollection<BsonDocument>("job");

            var filter = Builders<BsonDocument>.Filter.Eq("_id", model.id);
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

        public IJob? ReadElement(int id)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<BsonDocument>("job");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);

            var findAnn = collection.Find(filter).FirstOrDefault();


            //var rev = new List.reviews.ToList().Select(review => reviews.Add(new BsonDocument
            //{
            //    review.id = ["_id"],
            //    ["Text"] = review.text,
            //    ["Complaints"] = review.complaints,
            //    ["AuthorID"] = review.authorId.ToString(),
            //    ["BlockingId"] = review.blockingId.ToString()
            //}));

            IJob job = new Job
            {
                id = Convert.ToInt32(findAnn["_id"]),
                jobTitle = findAnn["jobTitle"].ToString(),
            };
            return job;
        }

        public List<IJob>? ReadList()
        {
            MongoClient dbClient = new MongoClient(@"mongodb://localhost:27017/Databases");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<BsonDocument>("job");

            var entities = new List<IJob>();

            var ann = collection.Find(new BsonDocument()).ToList();
            if (ann.Count == 0) 
            {
                return null;
            }
            var u = ann[0];
            ann.ForEach(u =>
            {
                try
                {
                    entities.Add(new Job
                    {
                        id = Convert.ToInt32(u["_id"]),
                        jobTitle = u["jobTitle"].ToString()
                    });
                }
                catch (Exception ex) { }
            });

            return entities;
        }

        public bool UpdateJob(IJob model)
        {
            MongoClient dbClient = new MongoClient(@"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.8.2");

            var database = dbClient.GetDatabase("database");
            var collection = database.GetCollection<BsonDocument>("job");
          
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", model.id);
                var update = Builders<BsonDocument>.Update.Set("jobTitle", model.jobTitle);
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
