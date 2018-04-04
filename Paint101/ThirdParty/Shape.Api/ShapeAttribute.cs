using System;

namespace Shape.Api
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ShapeAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }


        public ShapeAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
