using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Empire.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeathStarController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello From Docker";
        }
    }
}
