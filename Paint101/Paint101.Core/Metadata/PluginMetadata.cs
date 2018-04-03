namespace Paint101.Core
{
    public abstract class PluginMetadata
    {
        public PluginTypes Type { get; }

        public string DisplayName { get; set; }

        public string Description { get; set; }


        public PluginMetadata(PluginTypes type)
        {
            Type = type;
        }
    }
}
