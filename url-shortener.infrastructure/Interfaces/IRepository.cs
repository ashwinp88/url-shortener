namespace url_shortener.infrastructure.Interfaces;

public interface IRepository<T>
{
    Task<bool> KeyExistsAsync(string key);
    Task<string> AddAsync(string key, T value, TimeSpan ttl);
    Task<string> GetValueAsync(string key);
    Task RemoveAsync(string key); 
}
