namespace Paint101.Core
{
    public class PluginDescriptor : IPluginDescriptor
    {
        public PluginKey Key { get; }

        public string AssemblyPath => Key.AssemblyPath;

        public string Id => Key.DescriptorId;

        public IPluginMetadata Metadata { get; }


        public PluginDescriptor(PluginKey key, IPluginMetadata metadata)
        {
            Key = key;
            Metadata = metadata;
        }
    }
}
