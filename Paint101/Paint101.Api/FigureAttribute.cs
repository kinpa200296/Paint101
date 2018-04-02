using System;

namespace Paint101.Api
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FigureAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }


        public FigureAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
