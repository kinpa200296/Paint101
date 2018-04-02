namespace Paint101.Api
{
    public enum ParameterTypes
    {
        Int32,
        Double,
        String,
        Point,
        Rect,
        Color
    }


    public class Parameter
    {
        public string Key { get; set; }

        public ParameterTypes Type { get; set; }

        public string DisplayName { get; set; }


        public Parameter(string key, ParameterTypes type, string displayName)
        {
            Key = key;
            Type = type;
            DisplayName = displayName;
        }


        public override string ToString()
        {
            return $"Parameter(Key = {Key}, Type = {Type})";
        }
    }
}
