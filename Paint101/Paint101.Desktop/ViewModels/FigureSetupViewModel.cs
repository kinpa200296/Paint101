using Caliburn.Micro;
using Paint101.Core;
using System;
using System.Collections.ObjectModel;

namespace Paint101.Desktop.ViewModels
{
    public class FigureSetupViewModel : Screen
    {
        private AppService _appService;
        private FigureProxy _figureProxy;


        public ObservableCollection<ParameterViewModel> Parameters { get; }


        public FigureSetupViewModel(AppService appService, FigureProxy figureProxy)
        {
            _appService = appService;
            _figureProxy = figureProxy;

            DisplayName = $"{_figureProxy.Metadata.DisplayName} Setup";

            Parameters = new ObservableCollection<ParameterViewModel>();
            foreach (var parameter in figureProxy.Parameters.GetParameters())
            {
                Parameters.Add(CreateParameter(parameter, figureProxy.Parameters));
            }
        }


        public void Close()
        {
            TryClose();
        }


        private ParameterViewModel CreateParameter(Core.Parameter parameter, ParameterCollection parameters)
        {
            System.Action updateCallback = () => _appService.FigureCollection.UpdateFigure(_figureProxy);
            switch (parameter.Type)
            {
                case Api.ParameterTypes.Int32:
                    return new Int32ParameterViewModel(parameter, parameters, updateCallback);
                case Api.ParameterTypes.Double:
                    return new DoubleParameterViewModel(parameter, parameters, updateCallback);
                case Api.ParameterTypes.String:
                    return new StringParameterViewModel(parameter, parameters, updateCallback);
                case Api.ParameterTypes.Point:
                    return new PointParameterViewModel(parameter, parameters, updateCallback);
                case Api.ParameterTypes.Rect:
                    return new RectParameterViewModel(parameter, parameters, updateCallback);
                case Api.ParameterTypes.Color:
                    return new ColorParameterViewModel(parameter, parameters, updateCallback);
                default:
                    throw new ArgumentException("Unknown parameter type");
            }
        }
    }
}
