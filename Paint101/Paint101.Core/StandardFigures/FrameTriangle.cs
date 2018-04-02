using Paint101.Api;

namespace Paint101.Core.StandardFigures
{
    public class FrameTriangle : Figure
    {
        private Point _p1;
        private Point _p2;
        private Point _p3;
        private Color _color;


        public FrameTriangle(Point p1, Point p2, Point p3, Color color)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _color = color;
        }


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawLine(_p1, _p2, _color);
            canvas.DrawLine(_p1, _p3, _color);
            canvas.DrawLine(_p2, _p3, _color);
        }
    }
}
