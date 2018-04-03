using System;

namespace Paint101.Api
{
    public abstract class PluginAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }


        public PluginAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
