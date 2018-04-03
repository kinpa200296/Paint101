using System;

namespace Paint101.Api
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExtensionAttribute : PluginAttribute
    {
        public ExtensionAttribute(string displayName) : base(displayName)
        {
        }
    }
}
