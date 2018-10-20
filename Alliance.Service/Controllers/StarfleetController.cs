using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Alliance.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarfleetController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}