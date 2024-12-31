using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using url_shortener.infrastructure.DataStores.Interfaces;

namespace url_shortener.infrastructure.DataStores;

public class DynamoDbStore(IAmazonDynamoDB client) : IDataStore<string>
{
    private const string TableName = "urls";

    public async Task<bool> KeyExistsAsync(string key)
    {
        var resp = await GetItemResponse(key);
        return resp.HttpStatusCode == System.Net.HttpStatusCode.OK && resp.Item.Count > 0;
    }

    private async Task<GetItemResponse> GetItemResponse(string key)
    {
        var getItemRequest = new GetItemRequest
        {
            TableName = TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "shortUrl", new AttributeValue { S = key } }
            }
        };
        return await client.GetItemAsync(getItemRequest);
    }

    public async Task<string> AddOrUpdateAsync(string key, string value, TimeSpan ttl)
    {
        var ttlTimestamp = DateTimeOffset.UtcNow.Add(ttl).ToUnixTimeSeconds();
        var putItemRequest = new PutItemRequest
        {
            TableName = TableName,
            Item = new Dictionary<string, AttributeValue>
            {
                { "shortUrl", new AttributeValue { S = key } },
                { "longUrl", new AttributeValue { S = value } },
                { "ttl", new AttributeValue { S = ttlTimestamp.ToString() } }
            }
        };
        
        await client.PutItemAsync(putItemRequest);
        return key;
    }

    public async Task<string> GetValueAsync(string key)
    {
        var resp = await GetItemResponse(key);
        if (resp.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            return resp.Item["longUrl"].S;
        }
        throw new KeyNotFoundException();
    }

    public Task RemoveAsync(string key)
    {
        throw new NotImplementedException();
    }
}