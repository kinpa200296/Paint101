using Paint101.Api;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Paint101.Core
{
    public class Paint101AssemblyInspector : IAssemblyInspector
    {
        public List<IPluginDescriptor> InspectAssembly(Assembly assembly)
        {
            var res = new List<IPluginDescriptor>();
            foreach (var type in assembly.GetTypes())
            {
                var figureDesctiptor = CheckForFigure(type);
                if (figureDesctiptor != null)
                {
                    res.Add(figureDesctiptor);
                }

                var extensionDescriptor = CheckForExtension(type);
                if (extensionDescriptor != null)
                {
                    res.Add(extensionDescriptor);
                }
            }
            return res;
        }


        private IFigureDescriptor CheckForFigure(Type type)
        {
            if (!type.IsSubclassOf(typeof(Figure)))
                return null;

            var figureAttribute = type.GetCustomAttribute(typeof(FigureAttribute)) as FigureAttribute;
            if (figureAttribute == null)
                return null;

            var key = new PluginKey(type.Assembly.Location, type.FullName);
            var metadata = new FigureMetadata();
            SetPluginMetadata(metadata, figureAttribute, type);

            var descriptor = new FigureDescriptor(key, metadata, type);

            return descriptor;
        }

        private IExtensionDescriptor CheckForExtension(Type type)
        {
            if (!type.IsSubclassOf(typeof(Extension)))
                return null;

            var extensionAttribute = type.GetCustomAttribute(typeof(ExtensionAttribute)) as ExtensionAttribute;
            if (extensionAttribute == null)
                return null;

            var key = new PluginKey(type.Assembly.Location, type.FullName);
            var metadata = new FigureMetadata();
            SetPluginMetadata(metadata, extensionAttribute, type);

            var descriptor = new ExtensionDescriptor(key, metadata, type);

            return descriptor;
        }

        private void SetPluginMetadata(PluginMetadata metadata, PluginAttribute attribute, Type type)
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
