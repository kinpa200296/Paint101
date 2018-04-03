namespace Paint101.Core
{
    public enum PluginTypes
    {
        Figure,
        Extension,
    }


    public interface IPluginMetadata
    {
        PluginTypes Type { get; }

        string DisplayName { get; }

        string Description { get; }
    }


    public interface IFigureMetadata : IPluginMetadata
    {
    }


    public interface IExtensionMetadata : IPluginMetadata
    {
    }
}
