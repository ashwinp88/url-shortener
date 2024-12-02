namespace url_shortener.core;

public class CustomUrlTakenException : Exception
{
    public CustomUrlTakenException(string customUrl) : 
        base($"The short url: {customUrl} is already taken.")
    {
    }
}
