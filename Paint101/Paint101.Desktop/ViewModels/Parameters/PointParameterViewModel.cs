using System;
using Paint101.Core;
using Paint101.Api;

namespace Paint101.Desktop.ViewModels
{
    public class PointParameterViewModel : ParameterViewModel
    {
        private Point _value;


        public int X
        {
            get { return _value.X; }
            set
            {
                if (_value.X == value)
                    return;

                _value.X = value;
                NotifyOfPropertyChange(nameof(X));
                Update();
            }
        }

        public int Y
        {
            get { return _value.Y; }
            set
            {
                if (_value.Y == value)
                    return;

                _value.Y = value;
                NotifyOfPropertyChange(nameof(Y));
                Update();
            }
        }


        public PointParameterViewModel(Parameter parameter, ParameterCollection parameters, Action updateCallback)
            : base(parameter, parameters, updateCallback)
        {
            if (parameter.Value is Point)
            {
                _value = (Point)parameter.Value;
            }
            else
            {
                _value = new Point(0, 0);
                Parameters.SetParameter(Key, _value);
            }
        }
    }
}
