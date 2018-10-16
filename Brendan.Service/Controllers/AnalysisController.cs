using Microsoft.AspNetCore.Mvc;

namespace Brendan.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get(int id)
        {
            return "Hello From Docker";
        }
    }
}
