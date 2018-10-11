using Dan.Service.ApiClients.PaulServiceClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dan.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSessionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] PaulServiceClient client, CancellationToken cancellationToken)
        {
            var paulsAdvice = await client.Advice_GetAsync(cancellationToken);
            return Ok($"Paul says {string.Join(", ", paulsAdvice)}");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] PaulServiceClient client, CancellationToken cancellationToken)
        {
            await client.Advice_PostAsync(cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] PaulServiceClient client, CancellationToken cancellationToken)
        {
            await client.Advice_PutAsync(cancellationToken);
            return Ok();
        }
    }
}