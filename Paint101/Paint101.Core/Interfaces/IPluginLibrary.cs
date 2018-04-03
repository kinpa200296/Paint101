using System.Collections.Generic;

namespace Paint101.Core
{
    public interface IPluginLibrary
    {
        void Add(IPluginDescriptor descriptor);

        void AddRange(IEnumerable<IPluginDescriptor> descriptors);

        void Update(IPluginDescriptor descriptor);

        void Remove(PluginKey key);

        IPluginDescriptor Get(PluginKey key);

        List<IPluginDescriptor> GetByType(PluginTypes type);
    }
}
