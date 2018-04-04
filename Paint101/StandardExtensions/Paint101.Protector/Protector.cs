using System.IO;
using Paint101.Api;
using System.Security.Cryptography;

namespace Paint101.Protector
{
    [Extension("Protector")]
    public class Protector : Extension
    {
        public override Stream OnDeserializing(Stream stream)
        {
            byte[] bytes;
            using (stream)
            {
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
            }

            bytes = ProtectedData.Unprotect(bytes, null, DataProtectionScope.CurrentUser);
            return new MemoryStream(bytes);
        }

        public override Stream OnSerialized(Stream stream)
        {
            byte[] bytes;
            using (stream)
            {
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
            }

            bytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
            return new MemoryStream(bytes);
        }
    }
}
