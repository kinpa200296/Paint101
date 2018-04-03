using Paint101.Core;
using System;

namespace Paint101.Desktop.ViewModels
{
    public abstract class ParameterViewModel : Caliburn.Micro.PropertyChangedBase
    {
        protected Parameter Parameter { get; }

        protected ParameterCollection Parameters { get; }

        protected Action UpdateCallback { get; }


        public string Key => Parameter.Key;

        public string DisplayName => Parameter.DisplayName;


        public ParameterViewModel(Parameter parameter, ParameterCollection parameters, Action updateCallback)
        {
            Parameter = parameter;
            Parameters = parameters;
            UpdateCallback = updateCallback;
        }


        protected void Update()
        {
            UpdateCallback?.Invoke();
        }
    }
}
