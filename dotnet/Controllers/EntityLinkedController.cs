using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils.EntityLinking;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityLinkedController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Entity> entities = new List<Entity>();
            List<ILinkedResource> resources = new List<ILinkedResource>();
            resources.Add(new SampleRelatedResourceController());

            IResourceVisitor visitor = new ResourceVisitor();

            foreach (ILinkedResource resource in resources)
            {
                entities.AddRange(resource.Accept(visitor));
            }

            return Ok(entities);
        }
    }
}