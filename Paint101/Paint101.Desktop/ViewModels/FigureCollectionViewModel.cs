using Caliburn.Micro;
using Paint101.Core;

namespace Paint101.Desktop.ViewModels
{
    public class FigureCollectionViewModel : PropertyChangedBase
    {
        private FigureCollection _figureCollection;
        private CanvasViewModel _canvas;


        public FigureCollectionViewModel(FigureCollection figureCollection, CanvasViewModel canvas)
        {
            _figureCollection = figureCollection;
            _canvas = canvas;
        }


        public void Render()
        {
            _canvas.Render(_figureCollection);
        }
    }
}
