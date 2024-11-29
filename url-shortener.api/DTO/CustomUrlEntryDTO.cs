
using System.ComponentModel.DataAnnotations;

namespace url_shortener.DTO;

public class CustomUrlEntryDTO
{
    [Length(3, 50)]
    public string ShortUrl {get; set;} = "";

    [Url]
    public string Url {get; set;} = "";

}
