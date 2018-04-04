using System.IO;
using Paint101.Api;

namespace Paint101.Protector
{
    [Extension("Protector")]
    public class Protector : Extension
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
