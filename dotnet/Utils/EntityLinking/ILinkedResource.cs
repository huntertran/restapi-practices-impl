using System.Collections.Generic;

namespace sampleApi.Utils.EntityLinking
{
    public interface ILinkedResource
    {
        ICollection<Entity> Accept(IResourceVisitor visitor);
    }
}