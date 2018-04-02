using Paint101.Api;
using Paint101.Core;
using Paint101.Core.StandardFigures;

namespace Paint101.Desktop.ViewModels
{
    public class CanvasViewModel
    {
        private FigureCollection _figureCollection;
        private CanvasData _canvasData;


        public ICanvasData CanvasData => _canvasData;


        public CanvasViewModel()
        {
            _figureCollection = new FigureCollection();
            _canvasData = new CanvasData(500, 500);

            SeedDummyFigures();
        }


        public void Render()
        {
            _canvasData.ResetCanvas(PredefinedColors.White);
            _figureCollection.DrawFigures(_canvasData);
            _canvasData.FireRenderEvent();
        }


        private void SeedDummyFigures()
        {
            _figureCollection.AddFigure(new Line(new Point(100, 100), new Point(200, 100), PredefinedColors.Red));
            _figureCollection.AddFigure(new Line(new Point(100, 100), new Point(200, 200), PredefinedColors.Green));
            _figureCollection.AddFigure(new Line(new Point(100, 100), new Point(100, 200), PredefinedColors.Blue));
            _figureCollection.AddFigure(new FrameRectangle(new Rect(100, 300, 200, 400), PredefinedColors.Black));
            _figureCollection.AddFigure(new FilledRectangle(new Rect(300, 300, 400, 400), PredefinedColors.Black));
            _figureCollection.AddFigure(new FrameEllipse(new Point(350, 150), 100, 100, PredefinedColors.Red));
            _figureCollection.AddFigure(new FilledEllipse(new Point(350, 150), 80, 60, PredefinedColors.Green));
            _figureCollection.AddFigure(new FrameTriangle(new Point(250, 250), new Point(300, 200), new Point(300, 300), PredefinedColors.Blue));
            _figureCollection.AddFigure(new FrameTriangle(new Point(250, 250), new Point(200, 200), new Point(200, 300), PredefinedColors.Blue));
        }
    }
}
