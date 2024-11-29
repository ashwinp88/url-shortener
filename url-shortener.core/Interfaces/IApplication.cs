namespace url_shortener.core.interfaces;

public interface IApplication
{
    Task<bool> ShortUrlExists(string? url);
    Task<string> GenerateShortUrl(string? url, string? shortUrl = null);
    Task RemoveShortUrl(string? shortUrl);
    Task<string> GetFullUrl(string? shortUrl);
}
