using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroceryStoreAPI.Repositories
{
    public class MongoDbRepository
    {

        public MongoClient client;

        public IMongoDatabase database;

        public MongoDbRepository()
        {

            client = new MongoClient("mongodb://127.0.0.1:27017");

            database = client.GetDatabase("Inventory");
        }
    }
}
