using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using sampleApi.Controllers;

namespace sampleApi.Utils.EntityLinking
{
    public abstract class CommonResourceVisitor
    {

        protected static Entity getEntityFromReflection(MethodInfo method)
        {
            var attribute = method.GetCustomAttribute<HttpMethodAttribute>();
            Entity entity = new Entity("/SampleRelatedResource/" + method.Name);

            switch (attribute)
            {
                case HttpGetAttribute:
                    entity.Method = "GET";
                    break;
                case HttpPostAttribute:
                    entity.Method = "POST";
                    break;
            }

            return entity;
        }

        protected static List<MethodInfo> getControllerActions(SampleRelatedResourceController sampleRelatedResourceController)
        {
            var methodInfos = sampleRelatedResourceController.GetType()
                                                             .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                                             .ToList();

            methodInfos = methodInfos.Where(x => x.ReturnType == typeof(IActionResult)).ToList();
            return methodInfos;
        }

    }
}