using MongoDB.Driver;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(MongoSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<User> Users =>
        _database.GetCollection<User>("Users");
}
