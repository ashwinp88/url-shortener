using url_shortener.core;
using url_shortener.core.Exceptions;
using url_shortener.core.interfaces;
using url_shortener.infrastructure.Interfaces;
using url_shortener.infrastructure.RandomStringGenerators.Interfaces;

namespace url_shortener.application;

public class Application : IApplication
{
    private readonly IDataStore<string> dataStore;
    private readonly IRandomStringGenerator generator;

    public Application(IDataStore<string> dataStore, IRandomStringGenerator generator)
    {
        this.dataStore = dataStore;
        this.generator = generator;
    }

    public async Task<string> GenerateShortUrl(string? url, string? shortUrl = null) 
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        if (shortUrl != null && await dataStore.KeyExistsAsync(shortUrl))
            throw new CustomUrlTakenException(shortUrl);
            
        shortUrl ??= await generateUniqueShortUrl();
        return await dataStore.AddOrUpdateAsync(shortUrl, url, TimeSpan.FromDays(30));
    }

    public async Task RemoveShortUrl(string? shortUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shortUrl);
        await dataStore.RemoveAsync(shortUrl);
    }

    public async Task<string> GetFullUrlAsync(string? shortUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shortUrl);
        if (! await dataStore.KeyExistsAsync(shortUrl))
            throw new UrlNotFoundException(shortUrl);
            
        return await dataStore.GetValueAsync(shortUrl);
    }

    private async Task<string> generateUniqueShortUrl()
    {
        string uniqueString = generator.Generate();
        while (await dataStore.KeyExistsAsync(uniqueString))
            uniqueString = generator.Generate();
        return uniqueString;
    }

}