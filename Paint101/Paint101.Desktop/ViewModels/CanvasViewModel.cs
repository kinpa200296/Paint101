using Caliburn.Micro;
using Paint101.Api;
using Paint101.Core;

namespace Paint101.Desktop.ViewModels
{
    public class CanvasViewModel : PropertyChangedBase, ICanvasRenderer
    {
        private Color _defaultColor;
        private CanvasProxy _canvasProxy;


        public ICanvas Canvas => _canvasProxy;

        public ICanvasData CanvasData => _canvasProxy;


        public CanvasViewModel(Color defaulColor, int width, int height)
        {
            _defaultColor = defaulColor;
            _canvasProxy = new CanvasProxy(width, height);
        }


        public void Render(IFigureCollection figureCollection)
        {
            _canvasProxy.ResetCanvas(_defaultColor);
            figureCollection.DrawFigures(_canvasProxy);
            _canvasProxy.FireRenderEvent();
        }
    }
}
