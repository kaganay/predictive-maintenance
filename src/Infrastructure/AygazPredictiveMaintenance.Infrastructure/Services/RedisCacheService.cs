using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PredictiveMaintenance.Domain.Interfaces;
using StackExchange.Redis;

namespace PredictiveMaintenance.Infrastructure.Services;

public class RedisCacheService : ICacheService, IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly IDatabase _database;
    private readonly ConnectionMultiplexer _redis;

    public RedisCacheService(IConfiguration configuration)
    {
        _configuration = configuration;
        var connectionString = _configuration["Redis:ConnectionString"] ?? "localhost:6379";
        _redis = ConnectionMultiplexer.Connect(connectionString);
        _database = _redis.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key) where T : class
    {
        var value = await _database.StringGetAsync(key);
        if (!value.HasValue)
            return null;

        return JsonSerializer.Deserialize<T>(value!);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null) where T : class
    {
        var json = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, json, expiration);
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }

    public async Task RemoveByPatternAsync(string pattern)
    {
        var endpoints = _redis.GetEndPoints();
        var server = _redis.GetServer(endpoints.First());
        var keys = server.Keys(pattern: pattern);

        await foreach (var key in keys.ToAsyncEnumerable())
        {
            await _database.KeyDeleteAsync(key);
        }
    }

    public void Dispose()
    {
        _redis?.Dispose();
    }
}

