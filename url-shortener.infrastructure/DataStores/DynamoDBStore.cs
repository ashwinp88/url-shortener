using Amazon.DynamoDBv2;
using url_shortener.infrastructure.DataStores.Interfaces;

namespace url_shortener.infrastructure.DataStores;

public class DynamoDbStore(AmazonDynamoDBClient client) : IDataStore<string>
{
    public Task<bool> KeyExistsAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<string> AddOrUpdateAsync(string key, string value, TimeSpan ttl)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetValueAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string key)
    {
        throw new NotImplementedException();
    }
}