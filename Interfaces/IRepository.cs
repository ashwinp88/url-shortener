namespace url_shortener.Interfaces;

public interface IRepository<T>
{
    Task<bool> keyExistsAsync(string key);
    Task<string> addAsync(string key, T value, TimeSpan ttl);
    Task<string> getValueAsync(string key);
    Task removeAsync(string key); 
}
