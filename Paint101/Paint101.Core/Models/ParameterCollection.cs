using Paint101.Api;
using System.Collections.Generic;
using System.Linq;

namespace Paint101.Core
{
    public class Parameter
    {
        public string Key { get; }

        public string DisplayName { get; }

        public ParameterTypes Type { get; }

        public object DefaultValue { get; }

        public object Value { get; set; }


        public Parameter(string key, string displayName, ParameterTypes type, object defaultValue)
        {
            Key = key;
            DisplayName = displayName;
            Type = type;
            DefaultValue = defaultValue;
            Value = defaultValue;
        }
    }


    public class ParameterCollection : IParameterCollection
    {
        private Dictionary<string, Parameter> _parameters;


        public ParameterCollection()
        {
            _parameters = new Dictionary<string, Parameter>();
        }


        public object GetParameter(string key)
        {
            return _parameters[key].Value;
        }

        public T GetParameter<T>(string key)
        {
            return (T)_parameters[key].Value;
        }

        public void RegisterParameter(ParameterTypes type, string key, object defaultValue)
        {
            _parameters[key] = new Parameter(key, key, type, defaultValue);
        }

        public void RegisterParameter(ParameterTypes type, string key, object defaultValue, string displayName)
        {
            _parameters[key] = new Parameter(key, displayName, type, defaultValue);
        }

        public List<Parameter> GetParameters()
        {
            return _parameters.Values.ToList();
        }

        public void SetParameter(string key, object value)
        {
            if (_parameters.ContainsKey(key))
            {
                _parameters[key].Value = value;
            }
        }
    }
}
