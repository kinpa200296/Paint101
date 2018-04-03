using Paint101.Api;
using System;

namespace Paint101.Core
{
    public class FigureProxy : PluginProxy
    {
        private readonly ICoreLogger _logger = CoreLoggerFactory.GetLogger(nameof(FigureProxy));
        private Figure _figure;


        public ParameterCollection Parameters { get; }


        public FigureProxy(IFigureDescriptor descriptor) : base(descriptor)
        {
            _figure = descriptor.CreateInstance();
            Parameters = new ParameterCollection();
            RegisterParameters();
        }


        public void Draw(ICanvas canvas)
        {
            try
            {
                _figure.Draw(canvas, Parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Metadata.DisplayName} failed to execute Draw()", ex);
            }
        }


        private void RegisterParameters()
        {
            try
            {
                _figure.RegisterParameters(Parameters);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{Metadata.DisplayName} failed to execute RegisterParameters()", ex);
            }
        }
    }
}
