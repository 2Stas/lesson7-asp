using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace lesson7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetProfile()
        {
            return Ok("You are authenticated!");
        }
    }
}
