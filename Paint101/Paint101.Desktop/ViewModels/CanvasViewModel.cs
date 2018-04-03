using Caliburn.Micro;
using Paint101.Api;
using Paint101.Core;

namespace Paint101.Desktop.ViewModels
{
    public class CanvasViewModel : PropertyChangedBase
    {
        private Color _defaultColor;
        private CanvasProxy _canvasProxy;


        public ICanvasData CanvasData => _canvasProxy;


        public CanvasViewModel(Color defaulColor, int width, int height)
        {
            _defaultColor = defaulColor;
            _canvasProxy = new CanvasProxy(width, height);
        }


        public void Render(FigureCollection figureCollection)
        {
            _canvasProxy.ResetCanvas(_defaultColor);
            figureCollection.DrawFigures(_canvasProxy);
            _canvasProxy.FireRenderEvent();
        }
    }
}
