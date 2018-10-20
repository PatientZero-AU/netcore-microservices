using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HanSolo.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MillenniumFalconController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( new string[] { "Blah 1", "Blah 2" } );
        }
    }
}
