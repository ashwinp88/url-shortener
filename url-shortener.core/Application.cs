using url_shortener.core.interfaces;
using url_shortener.infrastructure.Interfaces;

namespace url_shortener.application;

public class Application : IApplication
{
    private readonly DateTime baseLine = new(2020, 7, 5);
    private readonly IRepository<string> repository;
    public Application(IRepository<string> repository)
    {
        this.repository = repository;
    }

    public async Task<string> GenerateShortUrl(string? url, string? shortUrl = null) 
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        if (shortUrl != null && await repository.KeyExistsAsync(shortUrl))
            throw new ArgumentException("The given short url is taken.");
            
        shortUrl ??= await generateUniqueShortUrl();
        return await repository.AddAsync(shortUrl, url, TimeSpan.FromDays(30));
    }

    public async Task RemoveShortUrl(string? shortUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shortUrl);
        await repository.RemoveAsync(shortUrl);
    }

    public async Task<string> GetFullUrlAsync(string? shortUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shortUrl);
        return await repository.GetValueAsync(shortUrl);
    }

    public Task<bool> ShortUrlExistsAsync(string? url)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        return repository.KeyExistsAsync(url);
    }

    private async Task<string> generateUniqueShortUrl()
    {
        string uniqueString = generateString();   
        while (await repository.KeyExistsAsync(uniqueString))
            uniqueString = generateString();
        return uniqueString;
    }

    private string generateString() 
    {
        var ticks = DateTime.UtcNow.Ticks - baseLine.Ticks;
        return ticks.ToString("x"); 
    }

}