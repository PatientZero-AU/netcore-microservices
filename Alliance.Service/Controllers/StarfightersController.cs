using Microsoft.AspNetCore.Mvc;
using Pz.Shared.ApiClients.HanSoloServiceClient;
using System.Threading;
using System.Threading.Tasks;

namespace Alliance.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarfightersController : ControllerBase
    {
        readonly HanSoloServiceClient _client;
        public StarfightersController(HanSoloServiceClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            var response = await _client.Chewbacca_PostAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(CancellationToken cancellationToken)
        {
            var response = await _client.Chewbacca_PutAsync();
            return Ok();
        }
    }
}