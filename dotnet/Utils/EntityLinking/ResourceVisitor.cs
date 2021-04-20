using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using sampleApi.Controllers;

namespace sampleApi.Utils.EntityLinking
{
    public class ResourceVisitor : IResourceVisitor
    {
        public ICollection<Entity> visit(SampleRelatedResourceController sampleRelatedResourceController)
        {
            var entities = new List<Entity>();

            var methodInfos = sampleRelatedResourceController.GetType()
                                                             .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                                             .ToList();

            methodInfos = methodInfos.Where(x => x.ReturnType == typeof(IActionResult)).ToList();

            foreach (MethodInfo method in methodInfos)
            {
                var attribute = method.GetCustomAttribute<HttpMethodAttribute>();
                if (attribute is HttpGetAttribute)
                {
                    string link = method.Name;
                    Entity entity = new Entity("/SampleRelatedResource/" + link, "GET");
                    entities.Add(entity);
                }
            }

            return entities;
        }
    }
}