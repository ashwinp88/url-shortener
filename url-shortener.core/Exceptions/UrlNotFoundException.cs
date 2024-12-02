using System;

namespace url_shortener.core.Exceptions;

public class UrlNotFoundException: Exception
{
    public UrlNotFoundException(string url) : 
        base($"The short url: {url} was not found or has expired.")
    {
    }
}
