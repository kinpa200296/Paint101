using Paint101.Api;

namespace Paint101.Core.StandardFigures
{
    public class FilledRectangle : Figure
    {
        private Rect _rect;
        private Color _color;


        public FilledRectangle(Rect rect, Color color)
        {
            _rect = rect;
            _color = color;
        }

        public FilledRectangle(Point p1, Point p2, Color color)
        {
            _rect = new Rect(p1, p2);
            _color = color;
        }


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFilledRectangle(_rect, _color);
        }
    }
}
