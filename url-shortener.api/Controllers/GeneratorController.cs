using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetOne([Required]string shortUrl) {
            if (!await app.ShortUrlExistsAsync(shortUrl)) {
                return NotFound();
            }
            return Ok(await app.GetFullUrlAsync(shortUrl));
        }

        [HttpPost("Generate")]
        public async Task<IActionResult> GenerateShortUrl(UrlEntryDTO urlEntryDTO) {
            var shortUrl = await app.GenerateShortUrl(urlEntryDTO.Url);
            return CreatedAtAction(nameof(GetOne), new { shortUrl }, shortUrl);
        }

        [HttpPost("GenerateCustom")]
        public async Task<IActionResult> GenerateCustomShortUrl(CustomUrlEntryDTO customUrlEntryDTO)
        {
            if (await app.ShortUrlExistsAsync(customUrlEntryDTO.ShortUrl))
            {
                return Conflict("This short url is taken.");
            }
            var shortUrl = await app.GenerateShortUrl(customUrlEntryDTO.Url, customUrlEntryDTO.ShortUrl);
            return CreatedAtAction(nameof(GetOne), new { shortUrl }, shortUrl);
        }

    }
}
