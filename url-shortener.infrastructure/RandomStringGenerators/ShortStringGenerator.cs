using System.Text;
using url_shortener.infrastructure.RandomStringGenerators.Interfaces;

namespace url_shortener.infrastructure.RandomStringGenerators;

public class ShortStringGenerator : IRandomStringGenerator
{
    private readonly Random _random = new();
    private const int Length = 5;
    
    public string Generate()
    {
        StringBuilder sb = new();
        for (int i = 0; i < Length; i++)
        {
            var rnd = _random.Next(0, 3);
            switch (rnd)
            {
                case 0:
                    sb.Append(_random.Next(0, 10));
                    break;
                case 1:
                    sb.Append((char)_random.Next('a', 'z' + 1));
                    break;
                case 2:
                    sb.Append((char)_random.Next('A', 'Z' + 1));
                    break;
            }
        }
        return sb.ToString();
    }
}