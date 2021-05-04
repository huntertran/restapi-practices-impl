using System;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils.ContentNegotiation.Models;

namespace sampleApi.Controllers
{
    /// <summary>
    /// In Startup.cs, add/modify the following code in ConfigureService method to support XML
    /// services.AddControllers(options =>
    /// {
    ///     options.RespectBrowserAcceptHeader = true;
    /// }).AddXmlDataContractSerializerFormatters();
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContentNegotiationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Resource()
        {
            Weather[] weathers = new Weather[2];

            DateTime today = DateTime.Now;

            weathers[0] = new Weather(today, 15.6);
            weathers[1] = new Weather(today.AddDays(1), 17);

            return Ok(weathers);
        }
    }
}