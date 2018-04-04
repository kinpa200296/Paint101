using Paint101.Api;
using System;
using System.IO;

namespace Paint101.Core
{
    public class ExtensionProxy : PluginProxy
    {
        private readonly ICoreLogger _logger = CoreLoggerFactory.GetLogger(nameof(ExtensionProxy));
        private Extension _extension;


        public ExtensionProxy(IExtensionDescriptor descriptor) : base(descriptor)
        {
            _extension = descriptor.CreateInstance();
        }


        public Stream OnSerialized(Stream stream)
        {
            try
            {
                return _extension.OnSerialized(stream);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Metadata.DisplayName} failed to execute OnSerialized()", ex);
                return null;
            }
        }

        public Stream OnDeserializing(Stream stream)
        {
            try
            {
                return _extension.OnDeserializing(stream);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Metadata.DisplayName} failed to execute OnDeserializing()", ex);
                return null;
            }
        }
    }
}
