
using Microsoft.Extensions.Caching.Memory;
using url_shortener.infrastructure.Interfaces;

namespace url_shortener;
public class InMemoryRepository : IDataStore<string>
{
    private readonly MemoryCacheOptions cacheOptions;
    private readonly MemoryCache memoryCache;

    public InMemoryRepository()
    {
        cacheOptions = new();
        memoryCache = new(cacheOptions);
    }

    public Task<string> AddAsync(string key, string value, TimeSpan ttl)
    {
        if (keyExists(key))
            throw new ArgumentException("Key Exists");
        memoryCache.Set(key, value, DateTimeOffset.UtcNow.Add(ttl));
        return Task.FromResult(key);
    }

    public Task<string> GetValueAsync(string key)
    {
        if (memoryCache.TryGetValue(key, out string? value))
            return Task.FromResult(value ?? "");
        throw new KeyNotFoundException();
    }

    public Task<bool> KeyExistsAsync(string key)
    {
        return Task.FromResult(keyExists(key));
    }

    public Task RemoveAsync(string key)
    {
        memoryCache.Remove(key);
        return Task.CompletedTask;
    }

    private bool keyExists(string key)
    {
        return memoryCache.TryGetValue(key, out string? _);
    }
}
