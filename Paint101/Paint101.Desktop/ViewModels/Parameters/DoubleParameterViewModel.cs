using Paint101.Core;
using System;

namespace Paint101.Desktop.ViewModels
{
    public class DoubleParameterViewModel : ParameterViewModel
    {
        private double _value;


        public double Value
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


        public DoubleParameterViewModel(Parameter parameter, ParameterCollection parameters, Action updateCallback)
            : base(parameter, parameters, updateCallback)
        {
            if (parameter.Value is double)
            {
                _value = (double)parameter.Value;
            }
            else
            {
                _value = default(double);
            }
        }
    }
}
