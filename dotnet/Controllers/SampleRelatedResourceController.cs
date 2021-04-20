using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils.EntityLinking;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SampleRelatedResourceController : ControllerBase, ILinkedResource
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public ICollection<Entity> Accept(IResourceVisitor visitor)
        {
            return visitor.visit(this);
        }

        [HttpGet]
        public IActionResult GetA()
        {
            return Ok("ok");
        }

        [HttpGet]
        public IActionResult GetB()
        {
            return Ok("ok");
        }

        [HttpGet]
        public IActionResult GetC()
        {
            return Ok("ok");
        }
    }
}