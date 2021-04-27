using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using sampleApi.Controllers;

namespace sampleApi.Utils.EntityLinking
{
    public class LogicCDResourceVisitor : CommonResourceVisitor, IResourceVisitor
    {
        public ICollection<Entity> visit(SampleRelatedResourceController sampleRelatedResourceController)
        {
            var entities = new List<Entity>();

            List<MethodInfo> methodInfos = getControllerActions(sampleRelatedResourceController);

            foreach (MethodInfo method in methodInfos)
            {
                Entity entity = getEntityFromReflection(method);
                entities.Add(entity);
            }

            return entities.Where(x => x.Uri.Contains("GetC") || x.Uri.Contains("GetD"))
                           .ToList();
        }
    }
}