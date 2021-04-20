using System.Collections.Generic;
using sampleApi.Controllers;

namespace sampleApi.Utils.EntityLinking
{
    public interface IResourceVisitor
    {
        ICollection<Entity> visit(SampleRelatedResourceController sampleRelatedResourceController);
    }
}