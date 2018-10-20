using Microsoft.AspNetCore.Mvc;

namespace Empire.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeathStarController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            return "Hello From Docker";
        }
    }
}
