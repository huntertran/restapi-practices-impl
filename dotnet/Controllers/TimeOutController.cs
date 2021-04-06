using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeOutController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int actualRunTime = 5000;
            int timeout = 2000;

            await TimeOut.TimeOutAfter(Task.Delay(actualRunTime), timeout);

            return Ok("ok");
        }
    }
}