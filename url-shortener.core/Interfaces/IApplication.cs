namespace url_shortener.core.interfaces;

public interface IApplication
{
    Task<string> GenerateShortUrl(string? url, string? shortUrl);
    Task RemoveShortUrl(string? shortUrl);
    Task<string> GetFullUrl(string? shortUrl);
}
