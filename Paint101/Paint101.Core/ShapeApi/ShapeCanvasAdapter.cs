using Paint101.Api;
using Shape.Api;

namespace Paint101.Core
{
    public class ShapeCanvasAdapter : ISimpleCanvas
    {
        private readonly ICanvas _canvas;


        public ShapeCanvasAdapter(ICanvas canvas)
        {
            _canvas = canvas;
        }


        public void DrawFrame(int x1, int y1, int x2, int y2)
        {
            _canvas.DrawFrameRectangle(new Rect(x1, y1, x2, y2), PredefinedColors.Black);
        }
    }
}
