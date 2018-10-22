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
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Get()
        {
            return Ok("Second fastest vessel in the galaxy");
        }
    }
}
