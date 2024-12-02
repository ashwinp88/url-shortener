using Microsoft.AspNetCore.Mvc;
using url_shortener.core.Exceptions;
using url_shortener.core.interfaces;

namespace url_shortener
{
    [Route("{id}")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IApplication app;

        public DefaultController(IApplication app)
        {
            this.app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Redirect(await app.GetFullUrlAsync(id));
            }
            catch (UrlNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
