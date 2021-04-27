namespace sampleApi.Utils.EntityLinking
{
    public class Entity
    {
        public string Uri
        {
            get;
            set;
        }

        public string Method
        {
            get;
            set;
        }

        public Entity(string uri, string method)
        {
            this.Uri = uri;
            this.Method = method;
        }

        public Entity(string uri)
        {
            this.Uri = uri;
        }
    }
}
