using Paint101.Api;

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
    }
}
