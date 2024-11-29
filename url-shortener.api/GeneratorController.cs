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
            if (!await app.ShortUrlExists(shortUrl)) {
                return NotFound();
            }
            return Ok(await app.GetFullUrl(shortUrl));
        }

        [HttpPost]
        public async Task<IActionResult> GenerateShortUrl(UrlEntryDTO urlEntryDTO) {
            var shortUrl = await app.GenerateShortUrl(urlEntryDTO.Url);
            return CreatedAtAction(nameof(GetOne), new { shortUrl }, shortUrl);
        }

    }
}
