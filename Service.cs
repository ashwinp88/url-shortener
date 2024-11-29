using url_shortener.Interfaces;

namespace url_shortener;

public class Service 
{
    private readonly DateTime baseLine = new(2020, 7, 5);
    private readonly IRepository<string> repository;
    public Service(IRepository<string> repository)
    {
        this.repository = repository;
    }

    public async Task<string> GenerateShortenedUrl(string? url) 
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        var shortUrl = await generateUniqueString();
        return await repository.addAsync(shortUrl, url, TimeSpan.FromDays(30));
    }

    public async Task RemoveShortenedUrl(string? shortUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(shortUrl);
        await repository.removeAsync(shortUrl);
    }

    private async Task<string> generateUniqueString()
    {
        string uniqueString = generateString();   
        while (await repository.keyExistsAsync(uniqueString))
            uniqueString = generateString();
        return uniqueString;
    }

    private string generateString() 
    {
        var ticks = DateTime.UtcNow.Ticks - baseLine.Ticks;
        return ticks.ToString("x"); 
    }
}