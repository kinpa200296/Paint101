using Shape.Api;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Paint101.Core
{
    public class ShapeAssemblyInspector : IAssemblyInspector
    {
        public List<IPluginDescriptor> InspectAssembly(Assembly assembly)
        {
            var res = new List<IPluginDescriptor>();
            foreach (var type in assembly.GetTypes())
            {
                var figureDesctiptor = CheckForShapeFigure(type);
                if (figureDesctiptor != null)
                {
                    res.Add(figureDesctiptor);
                }
            }
            return res;
        }


        private IFigureDescriptor CheckForShapeFigure(Type type)
        {
            if (!type.IsSubclassOf(typeof(ShapedFigure)))
                return null;

            var figureAttribute = type.GetCustomAttribute(typeof(ShapeAttribute)) as ShapeAttribute;
            if (figureAttribute == null)
                return null;

            var key = new PluginKey(type.Assembly.Location, type.FullName);
            var metadata = new FigureMetadata();
            SetPluginMetadata(metadata, figureAttribute, type);

            var descriptor = new ShapeDescriptor(key, metadata, type);

            return descriptor;
        }

        private void SetPluginMetadata(PluginMetadata metadata, ShapeAttribute attribute, Type type)
        {
            metadata.DisplayName =
                string.IsNullOrWhiteSpace(attribute?.DisplayName)
                ? type.Name
                : attribute.DisplayName;

            metadata.Description =
                string.IsNullOrWhiteSpace(attribute?.Description)
                ? null
                : attribute.Description;
        }
    }
}
