using Microsoft.AspNetCore.Mvc;
using System;
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
            SucceedIfRetried(3);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            await Fail();
            return Ok();
        }

        private void SucceedIfRetried(int attempts)
        {
            if (errCount >= attempts)
                return;
            ++errCount;
            throw new Exception();
        }

        private async Task Fail()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            throw new Exception();
        }
    }
}
