using System;
using System.Collections.Generic;

namespace Paint101.Core
{
    [Serializable]
    public class FigureConfig : PluginConfig
    {
        public List<ParameterConfig> Parameters { get; set; }


        public FigureConfig()
        {
            Parameters = new List<ParameterConfig>();
        }
    }
}
