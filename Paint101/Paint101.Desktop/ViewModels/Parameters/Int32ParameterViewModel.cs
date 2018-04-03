using System;
using Paint101.Core;

namespace Paint101.Desktop.ViewModels
{
    public class Int32ParameterViewModel : ParameterViewModel
    {
        private int _value;


        public int Value
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


        public Int32ParameterViewModel(Parameter parameter, ParameterCollection parameters, Action updateCallback)
            : base(parameter, parameters, updateCallback)
        {
            if (parameter.Value is int)
            {
                _value = (int)parameter.Value;
            }
            else
            {
                _value = default(int);
            }
        }
    }
}
