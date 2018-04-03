using System;

namespace Paint101.Core
{
    [Serializable]
    public class ParameterConfig
    {
        public string Key { get; set; }

        public object Value { get; set; }
    }
}
