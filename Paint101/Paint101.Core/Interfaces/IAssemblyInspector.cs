using System.Collections.Generic;
using System.Reflection;

namespace Paint101.Core
{
    public interface IAssemblyInspector
    {
        /// <summary>
        /// Inspects assembly to find compatible types
        /// </summary>
        /// <returns>List of compatible types</returns>
        List<IPluginDescriptor> InspectAssembly(Assembly assembly);
    }
}
