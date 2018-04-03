using System;
using Paint101.Core;
using Paint101.Api;

namespace Paint101.Desktop.ViewModels
{
    public class ColorParameterViewModel : ParameterViewModel
    {
        private Color _value;


        public byte Alpha
        {
            get { return _value.A; }
            set
            {
                if (_value.A == value)
                    return;

                _value.A = value;
                NotifyOfPropertyChange(nameof(Alpha));
                Update();
            }
        }

        public byte Red
        {
            get { return _value.R; }
            set
            {
                if (_value.R == value)
                    return;

                _value.R = value;
                NotifyOfPropertyChange(nameof(Red));
                Update();
            }
        }

        public byte Green
        {
            get { return _value.G; }
            set
            {
                if (_value.G == value)
                    return;

                _value.G = value;
                NotifyOfPropertyChange(nameof(Green));
                Update();
            }
        }

        public byte Blue
        {
            get { return _value.B; }
            set
            {
                if (_value.B == value)
                    return;

                _value.B = value;
                NotifyOfPropertyChange(nameof(Blue));
                Update();
            }
        }


        public ColorParameterViewModel(Parameter parameter, ParameterCollection parameters, Action updateCallback)
            : base(parameter, parameters, updateCallback)
        {
            if (parameter.Value is Color)
            {
                _value = (Color)parameter.Value;
            }
            else
            {
                _value = new Color(255, 0, 0, 0);
                Parameters.SetParameter(Key, _value);
            }
        }
    }
}
