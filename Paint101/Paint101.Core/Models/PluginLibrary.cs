using System.Collections.Generic;
using System.Linq;

namespace Paint101.Core
{
    public class PluginLibrary : IPluginLibrary
    {
        private Dictionary<PluginKey, IPluginDescriptor> _plugins;


        public PluginLibrary()
        {
            _plugins = new Dictionary<PluginKey, IPluginDescriptor>();
        }


        public void Add(IPluginDescriptor descriptor)
        {
            _plugins.Add(descriptor.Key, descriptor);
        }

        public void AddRange(IEnumerable<IPluginDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                _plugins.Add(descriptor.Key, descriptor);
            }
        }

        public void Update(IPluginDescriptor descriptor)
        {
            _plugins[descriptor.Key] = descriptor;
        }

        public void Remove(PluginKey key)
        {
            if (_plugins.ContainsKey(key))
            {
                _plugins.Remove(key);
            }
        }

        public IPluginDescriptor Get(PluginKey key)
        {
            return _plugins.ContainsKey(key) ? _plugins[key] : null;
        }

        public List<IPluginDescriptor> GetByType(PluginTypes type)
        {
            return _plugins.Values.Where(d => d.Metadata.Type == type).ToList();
        }
    }
}
