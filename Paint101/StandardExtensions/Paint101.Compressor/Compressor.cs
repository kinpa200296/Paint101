using System.IO;
using Paint101.Api;

namespace Paint101.Compressor
{
    [Extension("Compressor")]
    public class Compressor : Extension
    {
        public override Stream OnDeserializing(Stream stream)
        {
            throw new System.NotImplementedException();
        }

        public override Stream OnSerialized(Stream stream)
        {
            throw new System.NotImplementedException();
        }
    }
}
