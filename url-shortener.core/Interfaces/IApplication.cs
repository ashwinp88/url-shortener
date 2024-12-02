namespace url_shortener.core.interfaces;

public interface IApplication
{
    Task<string> GenerateShortUrl(string? url, string? shortUrl = null);
    Task RemoveShortUrl(string? shortUrl);
    Task<string> GetFullUrlAsync(string? shortUrl);
}
