using Paint101.Api;

namespace Paint101.Core.StandardFigures
{
    public class FilledEllipse : Figure
    {
        private Point _center;
        private int _width;
        private int _height;
        private Color _color;


        public FilledEllipse(Point center, int width, int height, Color color)
        {
            _center = center;
            _width = width;
            _height = height;
            _color = color;
        }

        public FilledEllipse(Rect rect, Color color)
        {
            _center = new Point((rect.X1 + rect.X2) / 2, (rect.Y1 + rect.Y2) / 2);
            _width = rect.X2 - rect.X1;
            _height = rect.Y2 - rect.Y1;
            _color = color;
        }


        public override void Draw(ICanvas canvas)
        {
            canvas.DrawFilledEllipse(_center, _width, _height, _color);
        }
    }
}
