
using Microsoft.Extensions.Caching.Memory;
using url_shortener.Interfaces;

namespace url_shortener;
public class InMemoryRepository : IRepository<string>
{
    private readonly MemoryCacheOptions cacheOptions;
    private readonly MemoryCache memoryCache;

    public InMemoryRepository()
    {
        cacheOptions = new();
        memoryCache = new(cacheOptions);
    }

    public Task<string> addAsync(string key, string value, TimeSpan ttl)
    {
        if (keyExists(key))
            throw new ArgumentException("Key Exists");

        return Task.FromResult(memoryCache.Set(key, value, DateTimeOffset.UtcNow.Add(ttl)));
    }

    public Task<string> getValueAsync(string key)
    {
        if (memoryCache.TryGetValue(key, out string? value))
            return Task.FromResult(value ?? "");
        throw new KeyNotFoundException();
    }

    public Task<bool> keyExistsAsync(string key)
    {
        return Task.FromResult(keyExists(key));
    }

    public Task removeAsync(string key)
    {
        memoryCache.Remove(key);
        return Task.CompletedTask;
    }

    private bool keyExists(string key)
    {
        return memoryCache.TryGetValue(key, out string? _);
    }
}
