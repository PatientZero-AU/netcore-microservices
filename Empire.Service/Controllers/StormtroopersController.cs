using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Empire.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StormtroopersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(void), 202)]
        public IActionResult ConsumeThread()
        {
            const int threads = 50;

            Parallel.For(0, threads, i =>
            {
                while (true) ;
            });

            return Accepted();
        }
    }
}