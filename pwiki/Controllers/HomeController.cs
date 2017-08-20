using Microsoft.AspNetCore.Mvc;

namespace pwiki.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World from a controller - V1");
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult Index2()
        {
            return Ok("Hello World from a controller - V2");
        }
    }
}
