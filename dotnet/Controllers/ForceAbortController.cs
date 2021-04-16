using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForceAbortController : ControllerBase
    {
        static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int actualRunTime = 10000;

            try
            {
                await Task.Delay(actualRunTime, cancellationTokenSource.Token);
            }
            catch (TaskCanceledException exception)
            {
                // 499 Client Closed Request
                // Used when the client has closed the request before the server could send a response.
                return StatusCode(499, "Client Closed Request before the server could send a response. Task cancelled with exception " + exception.Message);
            }

            return Ok("ok");
        }

        /// <summary>
        /// receive the cancel request
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(int taskId)
        {
            cancellationTokenSource.Cancel();
            return Ok("task " + taskId + " cancelled");
        }
    }
}