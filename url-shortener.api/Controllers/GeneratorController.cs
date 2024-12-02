using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using url_shortener.core;
using url_shortener.core.Exceptions;
using url_shortener.core.interfaces;
using url_shortener.DTO;

namespace url_shortener
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        private readonly IApplication app;

        public GeneratorController(IApplication app)
        {
            this.app = app;
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> GetOne([Required] string shortUrl)
        {
            try
            {
                string result = await app.GetFullUrlAsync(shortUrl);
                return Ok(result);
            }
            catch (UrlNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("Generate")]
        public async Task<IActionResult> GenerateShortUrl(UrlEntryDTO urlEntryDTO)
        {
            var shortUrl = await app.GenerateShortUrl(urlEntryDTO.Url);
            return CreatedAtAction(nameof(GetOne), new { shortUrl }, shortUrl);
        }

        [HttpPost("GenerateCustom")]
        public async Task<IActionResult> GenerateCustomShortUrl(CustomUrlEntryDTO customUrlEntryDTO)
        {
            try
            {
                var shortUrl = await app.GenerateShortUrl(customUrlEntryDTO.Url, customUrlEntryDTO.ShortUrl);
                return CreatedAtAction(nameof(GetOne), new { shortUrl }, shortUrl);
            }
            catch (CustomUrlTakenException e)
            {
                return Conflict(e.Message);
            }
        }

    }
}
