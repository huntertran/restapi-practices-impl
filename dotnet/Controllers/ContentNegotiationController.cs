using System;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils.ContentNegotiation.Models;

namespace sampleApi.Controllers
{
    /// <summary>
    /// In Startup.cs, add/modify the following code in ConfigureService method to support XML
    /// <example>
    /// <code>
    /// services.AddControllers(options =>
    /// {
    ///     options.RespectBrowserAcceptHeader = true;
    /// }).AddXmlDataContractSerializerFormatters();
    /// </code>
    /// </example>
    /// 
    /// If you want custom data format, take a look at https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/custom-formatters?view=aspnetcore-5.0
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

        [HttpGet]
        public string ResourceTest()
        {
            Weather[] weathers = new Weather[2];

            DateTime today = DateTime.Now;

            weathers[0] = new Weather(today, 15.6);
            weathers[1] = new Weather(today.AddDays(1), 17);

            return "test";
        }
    }
}