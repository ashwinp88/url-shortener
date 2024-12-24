using url_shortener.infrastructure.RandomStringGenerators.Interfaces;

namespace url_shortener.infrastructure.RandomStringGenerators;

public class TicksStringGenerator : IRandomStringGenerator
{
    private readonly DateTime _baseLine = new(2020, 7, 5);

    public string Generate()
    {
        var ticks = DateTime.UtcNow.Ticks - _baseLine.Ticks;
        return ticks.ToString("x"); 
    }
}
