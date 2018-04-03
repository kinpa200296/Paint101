using Paint101.Api;
using System;

namespace Paint101.Core
{
    public class FigureProxy : PluginProxy
    {
        private readonly ICoreLogger _logger = CoreLoggerFactory.GetLogger(nameof(FigureProxy));
        private Figure _figure;


        public FigureProxy(IFigureDescriptor descriptor) : base(descriptor)
        {
            _figure = descriptor.CreateInstance();
        }


        public void Draw(ICanvas canvas)
        {
            try
            {
                _figure.Draw(canvas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Metadata.DisplayName} failed to execute Draw()", ex);
            }
        }
    }
}
