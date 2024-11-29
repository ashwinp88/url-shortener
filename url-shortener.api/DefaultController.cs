using Microsoft.AspNetCore.Mvc;
using url_shortener.core.interfaces;

namespace url_shortener
{
    [Route("{id?}")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IApplication app;

        public DefaultController(IApplication app)
        {
            this.app = app;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) 
        {
            if (!string.IsNullOrWhiteSpace(id) && await app.ShortUrlExistsAsync(id))
            {
                return Redirect(await app.GetFullUrlAsync(id));
            }
            return NotFound();
        }
    }
}
