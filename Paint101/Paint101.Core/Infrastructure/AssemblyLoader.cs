using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Paint101.Core
{
    public static class AssemblyLoader
    {
        private static readonly ICoreLogger _logger;
        private static readonly List<IAssemblyInspector> _assemblyInspectors;


        static AssemblyLoader()
        {
            _logger = CoreLoggerFactory.GetLogger(nameof(AssemblyLoader));
            _assemblyInspectors = new List<IAssemblyInspector>();
        }


        public static void RegisterAssemblyInspector(IAssemblyInspector assemblyInspector)
        {
            _assemblyInspectors.Add(assemblyInspector);
        }

        /// <summary>
        /// Load assemblies from specified directory, inpect them and add found plugins
        /// </summary>
        public static void LoadPlugins(string dirPath, IPluginLibrary library)
        {
            foreach (var file in Directory.GetFiles(dirPath))
            {
                if (Path.GetExtension(file) == ".dll")
                {
                    InspectDll(file, library);
                }
            }
        }


        private static void InspectDll(string assemblyPath, IPluginLibrary library)
        {
            try
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                foreach (var assemblyInspector in _assemblyInspectors)
                {
                    var plugins = new List<IPluginDescriptor>();
                    try
                    {
                        plugins = assemblyInspector.InspectAssembly(assembly);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"{assemblyInspector.GetType().Name} failed to inpect assembly at {assemblyPath}", ex);
                    }

                    foreach (var plugin in plugins)
                    {
                        library.Add(plugin);
                        _logger.Log($"Loaded {plugin.Metadata.Type} '{plugin.Metadata.DisplayName}' from {assemblyPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to load assembly at {assemblyPath}", ex);
            }
        }
    }
}
