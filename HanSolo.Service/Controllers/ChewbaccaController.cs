using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HanSolo.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChewbaccaController : ControllerBase
    {
        private static int errCount = 0;

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