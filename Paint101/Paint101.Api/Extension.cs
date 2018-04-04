using System.IO;

namespace Paint101.Api
{
    public abstract class Extension
    {
        public abstract Stream OnSerialized(Stream stream);

        public abstract Stream OnDeserializing(Stream stream);
    }
}
