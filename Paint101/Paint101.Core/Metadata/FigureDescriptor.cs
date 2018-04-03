using Paint101.Api;
using System;

namespace Paint101.Core
{
    public class FigureDescriptor : PluginDescriptor, IFigureDescriptor
    {
        private readonly Type _type;


        public FigureDescriptor(PluginKey key, IPluginMetadata metadata, Type type)
            : base(key, metadata)
        {
            _type = type;
        }


        public Figure CreateInstance()
        {
            return (Figure)Activator.CreateInstance(_type);
        }
    }
}
