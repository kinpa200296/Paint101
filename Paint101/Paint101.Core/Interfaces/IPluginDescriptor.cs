using Paint101.Api;

namespace Paint101.Core
{
    public interface IPluginDescriptor
    {
        PluginKey Key { get; }

        string AssemblyPath { get; }

        string Id { get; }

        IPluginMetadata Metadata { get; }
    }


    public interface IFigureDescriptor : IPluginDescriptor
    {
        Figure CreateInstance();
    }


    public interface IExtensionDescriptor : IPluginDescriptor
    {
        Extension CreateInstance();
    }
}
