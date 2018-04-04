using System.IO;
using Paint101.Api;
using System.IO.Compression;

namespace Paint101.Compressor
{
    [Extension("Compressor")]
    public class Compressor : Extension
    {
        public override Stream OnDeserializing(Stream stream)
        {
            var memoryStream = new MemoryStream();
            using (var zipStream = new GZipStream(stream, CompressionMode.Decompress, true))
            {
                zipStream.CopyTo(memoryStream);
            }
            return memoryStream;
        }

        public override Stream OnSerialized(Stream stream)
        {
            var memoryStream = new MemoryStream();
            using (var zipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                stream.CopyTo(zipStream);
            }
            return memoryStream;
        }
    }
}
