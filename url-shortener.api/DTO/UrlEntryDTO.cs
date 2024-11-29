using System.ComponentModel.DataAnnotations;

namespace url_shortener.DTO;

public class UrlEntryDTO
{
    [Url]
    public string Url {get; set;} = "";

}
