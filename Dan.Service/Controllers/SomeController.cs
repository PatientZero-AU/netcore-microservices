using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Dan.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        //readonly PaulServiceClient _client;
        //public SomeController(PaulServiceClient client)
        //{
        //    _client = client;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(CancellationToken cancellationToken)
        //{
        //    var response = await _client.Advice_PostAsync();
        //    return Ok();
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put(CancellationToken cancellationToken)
        //{
        //    var response = await _client.Advice_PutAsync();
        //    return Ok();
        //}
    }
}