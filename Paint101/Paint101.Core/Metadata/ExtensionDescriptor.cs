using Paint101.Api;
using System;

namespace Paint101.Core
{
    public class ExtensionDescriptor : PluginDescriptor, IExtensionDescriptor
    {
        private readonly Type _type;


        public ExtensionDescriptor(PluginKey key, IPluginMetadata metadata, Type type)
            : base(key, metadata)
        {
            _type = type;
        }


        public Extension CreateInstance()
        {
            return (Extension)Activator.CreateInstance(_type);
        }
    }
}
