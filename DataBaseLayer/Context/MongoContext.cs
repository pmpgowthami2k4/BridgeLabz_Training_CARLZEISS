using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using ModelLayer.Entities;

namespace DataBaseLayer.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            _database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        }

        public IMongoCollection<User> Users =>
            _database.GetCollection<User>("Users");

        public IMongoCollection<Note> Notes =>
            _database.GetCollection<Note>("Notes");

        public IMongoCollection<Label> Labels =>
            _database.GetCollection<Label>("Labels");
    }
}
