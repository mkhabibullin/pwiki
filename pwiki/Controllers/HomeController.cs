using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pwiki.Controllers
{
    public class HomeController : Controller
    {
        [Route("home/")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World from a controller");
        }
    }
}
