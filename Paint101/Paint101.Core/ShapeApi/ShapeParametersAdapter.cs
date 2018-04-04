using Paint101.Api;
using Shape.Api;
using System;

namespace Paint101.Core
{
    public class ShapeParametersAdapter : IParameters
    {
        private readonly IParameterCollection _parameters;


        public ShapeParametersAdapter(IParameterCollection parameters)
        {
            _parameters = parameters;
        }


        public void AddParameter(string key, ParamTypes type, object defaultValue, string displayName)
        {
            _parameters.RegisterParameter(Convert(type), key, defaultValue, displayName);
        }

        public object GetParameter(string key)
        {
            return _parameters.GetParameter(key);
        }


        private ParameterTypes Convert(ParamTypes type)
        {
            switch (type)
            {
                case ParamTypes.Int32:
                    return ParameterTypes.Int32;
                default:
                    throw new ArgumentException("Unknown parameter type");
            }
        }
    }
}