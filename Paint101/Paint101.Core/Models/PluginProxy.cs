namespace Paint101.Core
{
    public abstract class PluginProxy
    {
        public PluginKey Key { get; }

        public IPluginMetadata Metadata { get; }


        public PluginProxy(IPluginDescriptor descriptor)
        {
            Key = descriptor.Key;
            Metadata = descriptor.Metadata;
        }
    }
}
