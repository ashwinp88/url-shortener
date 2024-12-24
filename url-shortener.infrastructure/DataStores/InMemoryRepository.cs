using Microsoft.Extensions.Caching.Memory;
using url_shortener.infrastructure.DataStores.Interfaces;

namespace url_shortener.infrastructure.DataStores;
public class InMemoryRepository : IDataStore<string>
{
    private readonly MemoryCacheOptions _cacheOptions;
    private readonly MemoryCache _memoryCache;

    public InMemoryRepository()
    {
        _cacheOptions = new();
        _memoryCache = new(_cacheOptions);
    }

    public Task<string> AddOrUpdateAsync(string key, string value, TimeSpan ttl)
    {
        _memoryCache.Set(key, value, DateTimeOffset.UtcNow.Add(ttl));
        return Task.FromResult(key);
    }

    public Task<string> GetValueAsync(string key)
    {
        if (_memoryCache.TryGetValue(key, out string? value))
            return Task.FromResult(value ?? "");
        throw new KeyNotFoundException();
    }

    public Task<bool> KeyExistsAsync(string key)
    {
        return Task.FromResult(KeyExists(key));
    }

    public Task RemoveAsync(string key)
    {
        _memoryCache.Remove(key);
        return Task.CompletedTask;
    }

    private bool KeyExists(string key)
    {
        return _memoryCache.TryGetValue(key, out string? _);
    }
}
