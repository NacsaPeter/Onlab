using Microsoft.AspNetCore.Mvc;

namespace Lynn.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [HttpGet("{picture}")]
        public IActionResult Get(string picture)
        {
            var image = System.IO.File.OpenRead($"wwwroot/{picture}");
            return File(image, "image/jpeg");
        }
    }
}