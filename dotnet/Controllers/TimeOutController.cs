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

            try
            {
                await TimeOut.TimeOutAfter(Task.Delay(actualRunTime), timeout);
            }
            catch
            {
                Response.Headers.Add("Connection", "close");
                return StatusCode(408, "Process Timeout");
            }

            return Ok("ok");
        }
    }
}