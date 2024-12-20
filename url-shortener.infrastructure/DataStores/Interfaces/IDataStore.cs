namespace url_shortener.infrastructure.Interfaces;

public interface IDataStore<T>
{
    Task<bool> KeyExistsAsync(string key);
    Task<string> AddOrUpdateAsync(string key, T value, TimeSpan ttl);
    Task<string> GetValueAsync(string key);
    Task RemoveAsync(string key); 
}
