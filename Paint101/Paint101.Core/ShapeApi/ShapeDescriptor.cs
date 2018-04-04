using Paint101.Api;
using Shape.Api;
using System;

namespace Paint101.Core
{
    public class ShapeDescriptor : PluginDescriptor, IFigureDescriptor
    {
        private readonly Type _type;


        public ShapeDescriptor(PluginKey key, IPluginMetadata metadata, Type type)
            : base(key, metadata)
        {
            _type = type;
        }

        public Figure CreateInstance()
        {
            return new ShapeAdapter((ShapedFigure)Activator.CreateInstance(_type));
        }
    }
}
