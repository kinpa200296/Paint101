using Paint101.Core;
using System;

namespace Paint101.Desktop.ViewModels
{
    public class StringParameterViewModel : ParameterViewModel
    {
        private string _value;


        public string Value
        {
            get { return _value; }
            set
            {
                if (_value == value)
                    return;

                _value = value;
                NotifyOfPropertyChange(nameof(Value));
                Parameters.SetParameter(Key, _value);
                Update();
            }
        }


        public StringParameterViewModel(Parameter parameter, ParameterCollection parameters, Action updateCallback)
            : base(parameter, parameters, updateCallback)
        {
            if (parameter.Value is string)
            {
                _value = (string)parameter.Value;
            }
            else
            {
                _value = default(string);
            }
        }
    }
}
