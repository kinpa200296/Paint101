using Paint101.Api;
using Paint101.Core;
using System;

namespace Paint101.Desktop.ViewModels
{
    public class RectParameterViewModel : ParameterViewModel
    {
        private Rect _value;


        public int X1
        {
            get { return _value.X1; }
            set
            {
                if (_value.X1 == value)
                    return;

                _value.X1 = value;
                NotifyOfPropertyChange(nameof(X1));
                Update();
            }
        }

        public int Y1
        {
            get { return _value.Y1; }
            set
            {
                if (_value.Y1 == value)
                    return;

                _value.Y1 = value;
                NotifyOfPropertyChange(nameof(Y1));
                Update();
            }
        }

        public int X2
        {
            get { return _value.X2; }
            set
            {
                if (_value.X2 == value)
                    return;

                _value.X2 = value;
                NotifyOfPropertyChange(nameof(X2));
                Update();
            }
        }

        public int Y2
        {
            get { return _value.Y2; }
            set
            {
                if (_value.Y2 == value)
                    return;

                _value.Y2 = value;
                NotifyOfPropertyChange(nameof(Y2));
                Update();
            }
        }


        public RectParameterViewModel(Parameter parameter, ParameterCollection parameters, Action updateCallback)
            : base(parameter, parameters, updateCallback)
        {
            if (parameter.Value is Rect)
            {
                _value = (Rect)parameter.Value;
            }
            else
            {
                _value = new Rect(0, 0, 0, 0);
                Parameters.SetParameter(Key, _value);
            }
        }
    }
}
