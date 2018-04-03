using System;

namespace Paint101.Api
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FigureAttribute : PluginAttribute
    {
        public FigureAttribute(string displayName) : base(displayName)
        {
        }
    }
}
