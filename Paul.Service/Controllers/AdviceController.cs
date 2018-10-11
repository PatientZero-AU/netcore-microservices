using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paul.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceController : ControllerBase
    {
        private static int errCount = 0;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( new string[] { "Blah 1", "Blah 2" } );
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            if (errCount > 3)
                return Ok();
            ++errCount;
            throw new System.Exception();
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            throw new System.Exception();
        }
    }
}
