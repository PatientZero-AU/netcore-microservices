using Microsoft.AspNetCore.Mvc;

namespace Dan.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSessionController : ControllerBase
    {
        
        public TrainingSessionController()
        {
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }
    }
}