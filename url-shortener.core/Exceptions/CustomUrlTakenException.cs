namespace url_shortener.core.Exceptions;

public class CustomUrlTakenException : Exception
{
    public CustomUrlTakenException(string customUrl) : 
        base($"The short url: {customUrl} is already taken.")
    {
    }
}
