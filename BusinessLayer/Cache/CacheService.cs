using System.Text.Json;
using BusinessLayer.Cache;
using StackExchange.Redis;

public class CacheService : ICacheService
{
    private readonly IDatabase _db;

    public CacheService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task<T> GetData<T>(string key)
    {
        var value = await _db.StringGetAsync(key);

        if (!value.IsNullOrEmpty)
        {
            return JsonSerializer.Deserialize<T>(value.ToString());
        }

        return default;
    }

    public async Task SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        var json = JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, json, expirationTime - DateTimeOffset.Now);
    }

    public async Task RemoveData(string key)
    {
        await _db.KeyDeleteAsync(key);
    }
}